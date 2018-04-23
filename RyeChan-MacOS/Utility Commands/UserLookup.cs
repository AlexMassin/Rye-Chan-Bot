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
using System.Text.RegularExpressions;
using System.Globalization;
using RyeChan_MacOS;

namespace RyeChanMacOS.UtilityCommands
{
    public class UserLookup : ModuleBase<SocketCommandContext>
    {
        #region Lookup Users
        [Command("whois")]
        public async Task lookupSelf()
        {
            SocketUser user = Context.User;
            var u = user as SocketGuildUser;
            String username = u.Username;
            String nickname = u.Nickname;
            if (nickname == "" || nickname == null) nickname = "NO NICKNAME";
            String playing = u.Game.ToString();
            if (playing == "" || playing == null) playing = "NOT PLAYING ANYTHING CURRENTLY";
            DateTimeOffset DTO = u.CreatedAt;
            #region DateTime stuff
            DTO = DTO.AddHours(-5);
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
            String created = Month + " " + DTO.Day + ", " + DTO.Year + " at " + hour + ":" + DTO.Minute.ToString("00") + ":" + DTO.Second.ToString("00") + " " + M + "  (UTC-05:00)[EST]";
            String avatarURL = u.GetAvatarUrl(ImageFormat.Gif, 1024);
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
            String joined = Month + " " + joinDTO.Day + ", " + joinDTO.Year + " at " + hour + ":" + joinDTO.Minute.ToString("00") + ":" + joinDTO.Second.ToString("00") + " " + M + "  (UTC-05:00)[EST]";

            var builder = new EmbedBuilder()
            {
                Color = new Color(0, 0, 0),
                Title = "Username: ",
                Description = username //soft hyphen to induce a newline
            };

            builder.AddField(x =>
            {
                x.Name = "Nickname: ";
                x.Value = nickname;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Created: ";
                x.Value = created;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Joined: ";
                x.Value = joined;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Discriminator: ";
                x.Value = "#" + discriminator;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Playing: ";
                x.Value = playing;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Avatar: ";
                x.Value = "[[Link]](" + avatarURL + ")";
                x.IsInline = false;
            });

            builder.ImageUrl = avatarURL;

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }

        [Command("whois")]
        public async Task lookupOthers([Remainder] String s)
        {
            var users = Context.Guild.Users;

            foreach (var u in users)
            {
                if (u.Username == s || u.Nickname == s || u.Mention == s)
                { //ignore how ugly and messy this looks, it was copy and pasted bruhh
                    String username = u.Username;
                    String nickname = u.Nickname;
                    if (nickname == "" || nickname == null) nickname = "NO NICKNAME";
                    String playing = u.Game.ToString();
                    if (playing == "" || playing == null) playing = "NOT PLAYING ANYTHING CURRENTLY";
                    DateTimeOffset DTO = u.CreatedAt;
                    #region DateTime stuff
                    DTO = DTO.AddHours(-5);
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
                    String created = Month + " " + DTO.Day + ", " + DTO.Year + " at " + hour + ":" + DTO.Minute.ToString("00") + ":" + DTO.Second.ToString("00") + " " + M + "  (UTC-05:00)[EST]";
                    String avatarURL = u.GetAvatarUrl(ImageFormat.Gif, 1024);
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
                    String joined = Month + " " + joinDTO.Day + ", " + joinDTO.Year + " at " + hour + ":" + joinDTO.Minute.ToString("00") + ":" + joinDTO.Second.ToString("00") + " " + M + " (UTC-05:00)[EST]";

                    var builder = new EmbedBuilder()
                    {
                        Color = new Color(0, 0, 0),
                        Title = "Username: ",
                        Description = username //soft hyphen to induce a newline
                    };

                    builder.AddField(x =>
                    {
                        x.Name = "Nickname: ";
                        x.Value = nickname;
                        x.IsInline = false;
                    });

                    builder.AddField(x =>
                    {
                        x.Name = "Created: ";
                        x.Value = created;
                        x.IsInline = false;
                    });

                    builder.AddField(x =>
                    {
                        x.Name = "Joined: ";
                        x.Value = joined;
                        x.IsInline = false;
                    });

                    builder.AddField(x =>
                    {
                        x.Name = "Discriminator: ";
                        x.Value = "#" + discriminator;
                        x.IsInline = false;
                    });

                    builder.AddField(x =>
                    {
                        x.Name = "Playing: ";
                        x.Value = playing;
                        x.IsInline = false;
                    });

                    builder.AddField(x =>
                    {
                        x.Name = "Avatar: ";
                        x.Value = "[[Link]](" + avatarURL + ")";
                        x.IsInline = false;
                    });

                    builder.ImageUrl = avatarURL;

                    await Context.Channel.SendMessageAsync("", false, builder.Build());

                }

            }
        }
        #endregion
    }
}
