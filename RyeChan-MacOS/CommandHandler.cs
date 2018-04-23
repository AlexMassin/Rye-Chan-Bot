using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RyeChan_MacOS
{
    public class CommandHandler
    {
        #region Protocols
        public static bool prtoclN = true; //no longer servicing
        #endregion
        public SocketUser recentlyBanned;
        public static SocketUser Glex;

        private DiscordSocketClient _client;

        private CommandService _service;

        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;

            _service = new CommandService();

            _service.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.MessageReceived += HandleCommandAsync;

            _client.UserJoined += welcomeUser;

            _client.UserLeft += byeUser;

            _client.UserBanned += bannedUser;


        }

        bool log = true;
        #region Handle Commands
        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;

            var context = new SocketCommandContext(_client, msg);

            int argPos = 0;
            if (msg.Author.Username == "Glex" && msg.Author.Discriminator == "9999" && Glex == null)
            {
                Glex = context.User;
                Console.WriteLine("Confessions ONLINE");
            }
            if (msg.HasCharPrefix('!', ref argPos) && !s.Author.IsBot)
            {
                var result = await _service.ExecuteAsync(context, argPos);
                String writer = s.Author.ToString();
                if (msg.Content.Contains("confess")) writer = "Anon";
                if (log) Console.WriteLine(writer + " attempted " + s.ToString());

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    if (log) Console.WriteLine("     attempt failed.");
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }

            #region Live response
            //Protocol N removed
            if (msg.Content.ToLower().Contains("<@407041206984376320>") && !msg.Content.ToLower().StartsWith("!") && !msg.Author.IsBot)
            {
                Console.WriteLine("Mention detected: " + msg);
                #region Responses
                String[] RandResponse = { "Suh dude?",
                                          "Need help? Just do !help",
                                          "Got a bug to report? DM GlexAomes.",
                                          "I can't get into a deep conversation with you, sorry :(",
                                          "How's life?",
                                          "Hey", 
                                          "Hiya",
                                          "Feeling lonely?",
                                          "You do know that I'm not a real person... Right?",
                                          "I hope you realize that I'm not a real person.",
                                          "Got something you need help with?",
                                          "Someone mentioned me?",
                                          "Does someone need my help?",
                                          "Lovely weather outside?",
                                          "Shouldn't you probably read or study with your free time?",
                                           msg.Author.Mention + ", yes?",
                                          "This isn't an anime, ok?",
                                          "I hope you don't have more than one waifus.",
                                          "Congratulations, you won a secret prize!\n\n\n Sike, do something more productive!"
                                        };
                #endregion
                Random rnd = new Random();
                int pick = rnd.Next(0, RandResponse.Length);
                await context.Channel.SendMessageAsync(RandResponse[pick]);

            }
            #endregion
        }
        #endregion
        //Passive events
        #region Welcomer

        private async Task welcomeUser(SocketGuildUser u)
        {
            var id = u.Guild.Id;
            var guildName = _client.GetGuild(id);
            int uCount = u.Guild.MemberCount;
            ulong chanID = 0;
            ulong genID = 0;

            //Get the default channel
            var cID = u.Guild.TextChannels;
            foreach (var x in cID)
            {
                if (x.ToString() == "welcome-mat")
                {
                    chanID = x.Id;
                    //break;
                }
                if (x.ToString() == "general")
                {
                    genID = x.Id;
                }
            }

            //Formatting the count
            string countMention = "";
            if (uCount % 10 == 1 && uCount % 100 != 11)
            {
                countMention = uCount + "st";
            }
            else if (uCount % 10 == 2 && uCount % 100 != 12)
            {
                countMention = uCount + "nd";
            }
            else if (uCount % 10 == 3 && uCount % 100 != 13)
            {
                countMention = uCount + "rd";
            }
            else
            {
                countMention = uCount + "th";
            }

            var channel = u.Guild.GetTextChannel(chanID);
            var general = u.Guild.GetTextChannel(genID);

            await channel.SendMessageAsync("Welcome to the " + guildName.ToString() + ", " + u.Mention + " , what's good?" + Environment.NewLine + "You are the " + countMention + " person in the server!");


            await general.SendMessageAsync("Here's our newest member!", false, lookupNew(u));

        }
        #endregion
        #region Lookup when Join
        private EmbedBuilder lookupNew(SocketGuildUser u)
        {
            String username = u.Username;
            String nickname = u.Nickname;
            if (nickname == "" || nickname == null) nickname = "NO NICKNAME";
            String playing = u.Game.ToString();
            if (playing == "" || playing == null) playing = "NOT PLAYING ANYTHING CURRENTLY";
            DateTimeOffset DTO = u.CreatedAt;
            #region DateTime stuff
            DTO = DTO.AddHours(-5);
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            String M = "AM";
            int hour = DTO.Hour;
            if (hour > 12)
            {
                M = "PM";
                hour -= 12;
            }
            if (hour == 0)
            {
                hour = 12;
            }
            int month = DTO.Month;
            String Month = "";
            switch (month)
            {
                case 1:
                    Month = "Jan";
                    break;

                case 2:
                    Month = "Feb";
                    break;

                case 3:
                    Month = "Mar";
                    break;

                case 4:
                    Month = "Apr";
                    break;

                case 5:
                    Month = "May";
                    break;

                case 6:
                    Month = "Jun";
                    break;

                case 7:
                    Month = "Jul";
                    break;

                case 8:
                    Month = "Aug";
                    break;

                case 9:
                    Month = "Sep";
                    break;

                case 10:
                    Month = "Oct";
                    break;

                case 11:
                    Month = "Nov";
                    break;

                case 12:
                    Month = "Dec";
                    break;
            }
            #endregion
            String created = Month + " " + DTO.Day + ", " + DTO.Year + " at " + hour + ":" + DTO.Minute.ToString("00") + ":" + DTO.Second.ToString("00") + " " + M + "  " + est.DisplayName.Substring(0, 11) + "[EST]";
            String avatarURL = u.GetAvatarUrl(ImageFormat.Png, 1024);
            if (avatarURL == "" || avatarURL == null)
            {
                avatarURL = $"{DiscordConfig.CDNUrl}embed/avatars/{u.DiscriminatorValue % 5}.png";
            }
            String discriminator = u.Discriminator.ToString();
            DateTimeOffset joinDTO = (DateTimeOffset)u.JoinedAt;
            #region Join DateTime stuff
            joinDTO = joinDTO.AddHours(-5);
            M = "AM";
            hour = joinDTO.Hour;
            if (hour > 12)
            {
                M = "PM";
                hour -= 12;
            }
            if (hour == 0)
            {
                hour = 12;
            }
            month = joinDTO.Month;
            Month = "";
            switch (month)
            {
                case 1:
                    Month = "Jan";
                    break;

                case 2:
                    Month = "Feb";
                    break;

                case 3:
                    Month = "Mar";
                    break;

                case 4:
                    Month = "Apr";
                    break;

                case 5:
                    Month = "May";
                    break;

                case 6:
                    Month = "Jun";
                    break;

                case 7:
                    Month = "Jul";
                    break;

                case 8:
                    Month = "Aug";
                    break;

                case 9:
                    Month = "Sep";
                    break;

                case 10:
                    Month = "Oct";
                    break;

                case 11:
                    Month = "Nov";
                    break;

                case 12:
                    Month = "Dec";
                    break;
            }
            #endregion
            String joined = Month + " " + joinDTO.Day + ", " + joinDTO.Year + " at " + hour + ":" + joinDTO.Minute.ToString("00") + ":" + joinDTO.Second.ToString("00") + " " + M + "  " + est.DisplayName.Substring(0, 11) + "[EST]";

            var builder = new EmbedBuilder()
            {
                Color = new Color(0, 0, 0),
                Title = "Username: ",
                Description = username //soft hyphen to induce a newline
            };

            builder.AddField(x => {
                x.Name = "Nickname: ";
                x.Value = nickname;
                x.IsInline = false;
            });

            builder.AddField(x => {
                x.Name = "Created: ";
                x.Value = created;
                x.IsInline = false;
            });

            builder.AddField(x => {
                x.Name = "Joined: ";
                x.Value = joined;
                x.IsInline = false;
            });

            builder.AddField(x => {
                x.Name = "Discriminator: ";
                x.Value = "#" + discriminator;
                x.IsInline = false;
            });

            builder.AddField(x => {
                x.Name = "Playing: ";
                x.Value = playing;
                x.IsInline = false;
            });

            builder.AddField(x => {
                x.Name = "Avatar: ";
                x.Value = "[[Link]](" + avatarURL + ")";
                x.IsInline = false;
            });

            builder.ImageUrl = avatarURL;
            return builder;
        }
        #endregion
        #region Goodbye User
        private async Task byeUser(SocketGuildUser u)
        {
            if (u == recentlyBanned)
            {
                recentlyBanned = null;
                return;
            }

            var id = u.Guild.Id;
            var guildName = _client.GetGuild(id);

            int uCount = u.Guild.MemberCount;

            ulong chanID = 0;

            //Get the default channel
            var cID = u.Guild.TextChannels;
            foreach (var x in cID)
            {
                if (x.ToString() == "welcome-mat")
                {
                    chanID = x.Id;
                    //break;
                }
            }

            var channel = u.Guild.GetTextChannel(chanID);

            String person = u.Nickname;
            if (person == "" || person == null)
            {
                person = u.Username;
            }

            person = "**" + person + "**";
            await channel.SendMessageAsync("Damn, looks like " + person + " left." + Environment.NewLine + "There are now " + uCount + " people in the " + guildName.ToString() + "!");
        }
        #endregion
        #region Banned User
        private async Task bannedUser(SocketUser u, SocketGuild g)
        {
            recentlyBanned = u;

            ulong chanID = 0;

            //Get the default channel
            var cID = g.TextChannels;
            foreach (var x in cID)
            {
                if (x.ToString() == "welcome-mat")
                {
                    chanID = x.Id;
                    //break; //comment if returning more than one
                }
            }
            var channel = g.GetTextChannel(chanID);

            String person = "**" + u.Username + "**";
            var id = g.Id;
            var guildName = _client.GetGuild(id);
            await channel.SendMessageAsync("Brace yourselves, ban hammer was just slammed upon " + person + "." + Environment.NewLine + "There are now " + g.MemberCount + " people in the " + guildName + "!");
            return;
        }
        #endregion
    }
}