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

namespace RyeChanMacOS
{
    public class Cmds : ModuleBase<SocketCommandContext>
    {
        #region Help
        [Command("help")]
        public async Task helpMessage()
        {
            var builder = new EmbedBuilder()
            {
                Color = new Color(255, 223, 0),
                Title = "Here is what you can do with Rye High Bot: ",
                Description = "\u00AD" //soft hyphen to induce a newline
            };

            builder.AddField(x =>
            {
                x.Name = "!about";
                x.Value = "General information." + Environment.NewLine;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "!say {message}";
                x.Value = "Says your message." + Environment.NewLine;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "!mock {message}";
                x.Value = "Mocks your message." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!pick {Choice 1, Choice 2, Choice 3.... etc}";
                x.Value = "Picks one of your choices randomly." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!ping";
                x.Value = "Returns the latency of the bot's response." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!trim {1 < count < 99}";
                x.Value = "Deletes a count number of numbers [REQUIRES MM PERMS]." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!conv {num} {baseA} to {baseB}";
                x.Value = "Converts num from baseA to baseB [DEC/BIN/OCT/HEX only]." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!playing {game} {override name}";
                x.Value = "Shows and lists [a-z] how many members are currently playing a game." + Environment.NewLine + "Adding {override name} at the end will force the name (no shortcut).";
            });

            builder.AddField(x =>
            {
                x.Name = "!members {role}";
                x.Value = "Shows and lists [a-z] how many members are in a role.";
            });

            builder.AddField(x =>
            {
                x.Name = "!avatar {username/nickname}";
                x.Value = "Gives you the URL of someone's avatar.";
            });

            builder.AddField(x =>
            {
                x.Name = "!desc";
                x.Value = "Gives you the channel's description.";
            });

            builder.AddField(x =>
            {
                x.Name = "!whois {username/nickname}";
                x.Value = "Gives you details about the user's account. Leave blank for info about yourself.";
            });

            builder.AddField(x =>
            {
                x.Name = "!feels";
                x.Value = "Gives you a random dank pepe.";
            });

            builder.AddField(x =>
            {
                x.Name = "!8ball {Yes or no question}";
                x.Value = "Acts like a Magic 8-Ball so ask it yes or no questions.";
            });

            builder.AddField(x =>
            {
                x.Name = "!fact";
                x.Value = "Gives you a random fun fact.";
            });

            builder.AddField(x =>
            {
                x.Name = "!confess {yourConfession, your biological sex}";
                x.Value = "Sends your confession for filtering and is posted anonymously.";
            });

            builder.AddField(x =>
            {
                x.Name = "!morph {firstWord} {secondWord}";
                x.Value = "Morphs the first word into the second word.";
            });

            builder.AddField(x =>
            {
                x.Name = "!poll help";
                x.Value = "Gives a help page for polls.";
            });

            builder.AddField(x =>
            {
                x.Name = "!page";
                x.Value = "Pushes chat up. Use this when something uncomfortable is in direct view [REQUIRES MM PERMS].";
            });

            builder.AddField(x =>
            {
                x.Name = "!protocol {[X]/list}";
                x.Value = "Entering list gives the list of protocols and entering [X] will toggle the activation status of [X] protocol.";
            });

            //END HERE

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
        #endregion
        #region About
        [Command("about")]
        public async Task about()
        {
            await Context.Channel.SendMessageAsync("This is a bot written by Alex Gomes in C# (.NET Core) with the Discord API.\n\nThis bot is dedicated to the Comp Sci Gang Discord server.\n\nIt is currently being worked on here and there with improvements, updates, and features.\n\nIf there's a feature you'd like to see added or a bug to fix, please DM or mention " +
                "Alex Gomes, `@GlexAomes#9999`.\n\nSpecial thanks to Judah for creating the server and my two helpful testers, Tony and Ethan.\n" +
                "V2.50_355a MACOS");
        }
        #endregion
        #region Say
        [Command("say")]
        public async Task sayMessage([Remainder] string s)
        {
            //Delete the command message
            var messages = await Context.Channel.GetMessagesAsync(1).Flatten();

            await Context.Channel.DeleteMessagesAsync(messages);

            SocketUser sUser = Context.User;
            var user = sUser as SocketGuildUser;

            if (s.Contains("@everyone") && !user.GuildPermissions.MentionEveryone)
            {
                s = s.Replace("@everyone", "everyone");
            }

            if (s != "")
            {
                await Context.Channel.SendMessageAsync(s);
                return;
            }
            else
            {
                await Context.Channel.SendMessageAsync("What did you want me to say?");
                return;
            }



        }
        #endregion
        #region Mock
        [Command("mock")]
        public async Task mockMessage([Remainder] string s)
        {
            //Delete command message
            var messages = await Context.Channel.GetMessagesAsync(1).Flatten();

            await Context.Channel.DeleteMessagesAsync(messages);

            SocketUser sUser = Context.User;
            var user = sUser as SocketGuildUser;

            if (s.Contains("@everyone") && !user.GuildPermissions.MentionEveryone)
            {
                s = s.Replace("@everyone", "everyone");
            }

            s = s.ToLower();

            string toOutput = "";
            char[] c = s.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (i % 2 == 0)
                {
                    char buffer = c[i];
                    c[i] = char.ToUpper(c[i]);
                }
                toOutput += c[i];
            }


            if (toOutput != "")
            {
                await Context.Channel.SendMessageAsync(toOutput);
            }
            else
            {
                await Context.Channel.SendMessageAsync("What do you want me to mock?");
            }

        }
        #endregion
        #region Page
        [Command("page")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]
        public async Task page()
        {
            //This is really ugly
            await Context.Channel.SendMessageAsync("\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine + "\u00AD" + Environment.NewLine);
            return;
        }
        #endregion
        #region Pick
        [Command("pick")]
        public async Task pick([Remainder] String s)
        {
            List<String> choices = @s.Split(",").ToList();

            for (int i = 0; i < choices.Count; i++)
            {
                String chc = choices[i];
                if (string.IsNullOrWhiteSpace(choices[i]))
                {
                    choices.RemoveAt(i);
                    i--;
                    continue;
                }
                choices[i] = choices[i].Trim();
            }
            if (choices.Count == 0)
            {
                await Context.Channel.SendMessageAsync("Doesn't look like there were any valid choices.");
                return;
            }
            if (choices.Count == 1)
            {
                await Context.Channel.SendMessageAsync(@"Well, there was only one choice so... I picked " + choices[0]);
                return;
            }
            else
            {
                Random rng = new Random();
                await Context.Channel.SendMessageAsync(@"I picked: " + choices[rng.Next(0, choices.Count)]);
                return;
            }
        }
        #endregion
        #region Trim
        [Command("trim")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]
        public async Task gutMessages(int count)
        {
            if (count < 100 && count > 0)
            {
                var messages = await Context.Channel.GetMessagesAsync(count + 1).Flatten(); //+1 to delete command message as well

                await Context.Channel.DeleteMessagesAsync(messages);
            }
            else
            {
                await Context.Channel.SendMessageAsync("Please keep maximum deletion between 1 and 99.");
            }

        }
        #endregion
        #region Morph
        [Command("morph")]
        public async Task morph(String a, String b)
        {
            String op = "";
            a = a.Trim();
            b = b.Trim();

            a = a.Replace("@", "\\@");
            b = b.Replace("@", "\\@");

            int start = 2;

            a = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(a);
            b = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(b);

            if (a[0] != b[0])
            {
                start = 1;
            }

            op += a.Substring(0, a.Length);

            for (int i = a.Length - 1; i >= 0; i--)
            {
                op += Environment.NewLine + a.Substring(0, i);
            }

            for (int i = start; i <= b.Length; i++)
            {
                op += b.Substring(0, i) + Environment.NewLine;
            }
            await Context.Channel.SendMessageAsync(op);
            return;
        }
        #endregion
        #region Number Converter
        [Command("conv")]
        public async Task convertNumber(string numb, params string[] s)
        {
            string op = "";
            Int64 num = -1;

            try
            {
                num = Convert.ToInt64(numb);
                if (num < 0)
                {
                    await Context.Channel.SendMessageAsync("Sorry dude, can't do negatives yet, in the future maybe.");
                    return;
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Caught " + x);
            }
            s[0] = s[0].ToLower();
            s[2] = s[2].ToLower();

            //Determine what the conversion is from and to

            //Start with BEAN cases
            if (numb == "0" || num == 0)
            {
                await Context.Channel.SendMessageAsync("Hahah, nice try dude, converting 0....");
                return;
            }
            else if (s[0] == s[2] && (s[0] == "dec" || s[0] == "bin" || s[0] == "oct" || s[0] == "hex"))
            {
                await Context.Channel.SendMessageAsync("Do you think I'm a bean?");
                return;
            }
            //Start with hex first cuz it's the only one that needs to start as string
            else if (s[0] == "hex" && s[2] == "dec")
            {
                //From HEX to DEC
                await Context.Channel.SendMessageAsync("Converting " + numb + " from HEX to DEC:");
                op = Convert.ToString(Convert.ToInt64(numb, 16), 10);
            }
            else if (s[0] == "hex" && s[2] == "bin")
            {
                //From HEX to BIN
                await Context.Channel.SendMessageAsync("Converting " + numb + " from HEX to BIN:");
                op = Convert.ToString(Convert.ToInt64(numb, 16), 2);
            }
            else if (s[0] == "hex" && s[2] == "oct")
            {
                //From HEX to OCT
                await Context.Channel.SendMessageAsync("Converting " + numb + " from HEX to OCT:");
                op = Convert.ToString(Convert.ToInt64(numb, 16), 8);
            }
            else if (s[0] == "dec" && s[2] == "bin")
            {
                //From DEC to BIN
                await Context.Channel.SendMessageAsync("Converting " + num + " from DEC to BIN:");
                op = Convert.ToString(num, 2);
            }
            else if (s[0] == "dec" && s[2] == "oct")
            {
                //From DEC to OCT
                await Context.Channel.SendMessageAsync("Converting " + num + " from DEC to OCT:");
                op = Convert.ToString(num, 8);
            }
            else if (s[0] == "dec" && s[2] == "hex")
            {
                //From DEC to HEX
                await Context.Channel.SendMessageAsync("Converting " + num + " from DEC to HEX:");
                op = Convert.ToString(num, 16);
            }
            else if (s[0] == "bin" && s[2] == "dec")
            {
                //From BIN to DEC
                await Context.Channel.SendMessageAsync("Converting " + num + " from BIN to DEC:");
                op = Convert.ToInt64(num.ToString(), 2).ToString();
            }
            else if (s[0] == "bin" && s[2] == "oct")
            {
                //From BIN to OCT
                await Context.Channel.SendMessageAsync("Converting " + num + " from BIN to OCT:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 2);
                op = Convert.ToString(buffer, 8);
            }
            else if (s[0] == "bin" && s[2] == "hex")
            {
                //From BIN to HEX
                await Context.Channel.SendMessageAsync("Converting " + num + " from BIN to HEX:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 2);
                op = Convert.ToString(buffer, 16);
            }
            else if (s[0] == "oct" && s[2] == "dec")
            {
                //From OCT to DEC
                await Context.Channel.SendMessageAsync("Converting " + num + " from OCT to DEC:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 8);
                op = Convert.ToString(buffer, 10);
            }
            else if (s[0] == "oct" && s[2] == "bin")
            {
                //From OCT to BIN
                await Context.Channel.SendMessageAsync("Converting " + num + " from OCT to BIN:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 8);
                op = Convert.ToString(buffer, 2);
            }
            else if (s[0] == "oct" && s[2] == "hex")
            {
                //From OCT to HEX
                await Context.Channel.SendMessageAsync("Converting " + num + " from OCT to HEX:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 8);
                op = Convert.ToString(buffer, 16);
            }

            if (op != "")
            {
                await Context.Channel.SendMessageAsync(op);
            }
            else if (s[2] != "dec" || s[2] != "bin" || s[2] != "oct" || s[2] != "hex")
            {
                await Context.Channel.SendMessageAsync("My dude, " + s[2] + " is not a valid type of base.");
            }
            else if (s[0] != "dec" || s[0] != "bin" || s[0] != "oct" || s[0] != "hex")
            {
                await Context.Channel.SendMessageAsync("My dude, " + s[0] + " is not a valid type of base.");
            }
            else if (op == "0" && numb != "0")
            {
                await Context.Channel.SendMessageAsync("Oh jeez, looks like I ran into a problem, your input: " + numb + "seems to have caused an error.");
                await Context.Channel.SendMessageAsync("Please contact my Alex.");
            }
            else
            {
                await Context.Channel.SendMessageAsync("Oh jeez, looks like I ran into a unknown problem, contact Alex please.");
            }

        }
        #endregion
        #region Ping-Pong
        [Command("ping")]
        public async Task pingPongMessage()
        {
            await ReplyAsync(Context.User.Mention + $" Pong! {(Context.Client as Discord.WebSocket.DiscordSocketClient).Latency} ms :ping_pong:");
        }
        #endregion
        #region Playing Game
        [Command("playing")]
        public async Task playingGame([Remainder] string game)
        {
            List<string> UserList = new List<string>();
            List<string> UserListSorted = new List<string>();
            bool ovrRide = false;
            string ovrRideDetect = "override name";
            if (game.ToLower().EndsWith(ovrRideDetect))
            {
                ovrRide = true;
                await Context.Channel.SendMessageAsync("Overriding name...");
                game = game.Remove(game.Length - ovrRideDetect.Length - 1, ovrRideDetect.Length + 1);
            }

            #region Shortcuts
            //Some shortcuts
            if (!ovrRide)
            {
                if (game.ToLower() == "league" || game.ToLower() == "lol" || game.ToLower() == "leg")
                {
                    game = "League of Legends";
                }
                else if (game.ToLower() == "wf")
                {
                    game = "Warframe";
                }
                else if (game.ToLower() == "osu")
                {
                    game = "osu!";
                }
                else if (game.ToLower() == "poe")
                {
                    game = "Path of Exile";
                }
                else if (game.ToLower() == "rl")
                {
                    game = "Rocket League";
                }
                else if (game.ToLower() == "csgo")
                {
                    game = "Counter-Strike Global Offensive";
                }
                else if (game.ToLower() == "wow")
                {
                    game = "World of Warcraft";
                }
                else if (game.ToLower() == "bf1" || game.ToLower() == "bf 1")
                {
                    game = "Battlefield 1";
                }
                else if (game.ToLower() == "d2" || game.ToLower() == "d2")
                {
                    game = "Destiny 2";
                }
                else if (game.ToLower() == "pubg")
                {
                    game = "PLAYERUNKNOWN'S BATTLEGROUNDS";
                }
                else if (game.ToLower() == "gta v" || game.ToLower() == "gta 5" || game.ToLower() == "gtav" || game.ToLower() == "gta5")
                {
                    game = "Grand Theft Auto V";
                }
                else if (game.ToLower() == "ddlc")
                {
                    game = "Doki Doki Literature Club";
                }
            }
            //Shortcuts end here
            #endregion

            var UsersPlayingGame = Context.Guild.Users.Where(x => x.Game.ToString().ToLower() == game.ToLower()).Distinct();

            foreach (var pUser in UsersPlayingGame)
            {
                string buffer = "";
                if (pUser.Nickname != "" || pUser.Nickname != null || pUser.Nickname != " " || pUser.Nickname != pUser.Username)
                {
                    buffer = ", *\"" + pUser.Nickname + "\"*";
                }
                if (buffer == ", *\"\"*")
                {
                    UserList.Add(pUser.Username);
                }
                else
                {
                    UserList.Add(pUser.Username + buffer);
                }
            }
            UserList.Sort();

            for (int i = 0; i < UserList.Count(); i++)
            {
                UserListSorted.Add(("__**" + (i + 1) + "**__") + ": " + UserList[i] + Environment.NewLine);
            }

            if (UserListSorted.Count() > 1)
            {
                await Context.Channel.SendMessageAsync("__**There are currently " + UserListSorted.Count() + " users playing " + game + ":**__" + Environment.NewLine + Environment.NewLine + string.Join("", UserListSorted));
            }
            else if (UserListSorted.Count() == 1)
            {
                await Context.Channel.SendMessageAsync("__**There is currently 1 user playing " + game + ":**__" + Environment.NewLine + Environment.NewLine + string.Join("", UserListSorted));
            }
            else
            {
                await Context.Channel.SendMessageAsync("__**There is currently no user playing " + game + "**__");
            }
        }
        #endregion
        #region Get Avatar
        [Command("avatar")]
        public async Task getAvatar([Remainder] string s)
        {
            var users = Context.Guild.Users;

            foreach (var u in users)
            {
                if (u.Username == s || u.Nickname == s || u.Mention == s)
                {
                    string name = u.Nickname;
                    if (u.Nickname == "" || u.Nickname == null)
                    {
                        name = u.Username;
                    }
                    string link = u.GetAvatarUrl(ImageFormat.Gif, 1024);
                    if (link == "" || link == null)
                    {
                        link = $"{DiscordConfig.CDNUrl}embed/avatars/{u.DiscriminatorValue % 5}.png";
                    }
                    await Context.Channel.SendMessageAsync(name + "'s avatar: " + Environment.NewLine + link);
                    //return;
                }
            }
        }
        [Command("avatar")]
        public async Task getAvatarSelf()
        {
            await Context.Channel.SendMessageAsync(Context.User.Username + "'s avatar: " + Environment.NewLine + Context.User.GetAvatarUrl(ImageFormat.Png, 1024));
            return;

        }
        #endregion
        #region Random pepe-feels image getter
        [Command("feels")]
        public async Task pepeFeels()
        {
            SocketUser s = Context.User;
            var u = s as SocketGuildUser;

            string[] img = new string[28];
            string[] name = new string[28];

            Random rnd = new Random();
            int pick = rnd.Next(0, img.Length);

            #region populate repositry
            img[0] = "https://i.imgur.com/zfgIbul.png";
            name[0] = "feels bad man";

            img[1] = "https://i.imgur.com/D6rAsCV.png";
            name[1] = "feels good man";

            img[2] = "https://i.imgur.com/n59PM8O.png";
            name[2] = "feels smug man";

            img[3] = "https://i.imgur.com/yJOfpfZ.png?1";
            name[3] = "feels very sad man";

            img[4] = "https://i.imgur.com/GQ8XsSp.png";
            name[4] = "feels trap man";

            img[5] = "https://i.imgur.com/3MzIsGg.png";
            name[5] = "feels angry man";

            img[6] = "https://i.imgur.com/gsgISog.png";
            name[6] = "feels trippy man";

            img[7] = "https://i.imgur.com/sAWXi0h.png";
            name[7] = "feels ugly man";

            img[8] = "https://i.imgur.com/5Hf807l.png";
            name[8] = "feels feed man";

            img[9] = "https://i.imgur.com/Gtryhb1.png";
            name[9] = "feels bitter man";

            img[10] = "https://i.imgur.com/Qxwzm7m.png";
            name[10] = "feels handsome man";

            img[11] = "https://i.imgur.com/8t0igvA.png";
            name[11] = "feels fast man";

            img[12] = "https://i.imgur.com/RIS7iaY.png";
            name[12] = "feels :regional_indicator_d::regional_indicator_e::regional_indicator_a::regional_indicator_d::regional_indicator_a::regional_indicator_s::regional_indicator_s: :b:";

            img[13] = "https://i.imgur.com/JjMkWSg.png";
            name[13] = "feels jacked man";

            img[14] = "https://i.imgur.com/KukMmwj.png";
            name[14] = "feels crying man";

            img[15] = "https://i.imgur.com/4XmMBcT.png";
            name[15] = "feels suicidal man";

            img[16] = "https://i.imgur.com/2Ea5fbL.png?1";
            name[16] = "fols bod mon";

            img[17] = "https://i.imgur.com/B18EU3B.png";
            name[17] = "feels special man";

            img[18] = "https://i.imgur.com/iJg2zT0.png";
            name[18] = "feels triggered man";

            img[19] = "https://i.imgur.com/BjOfa94.png";
            name[19] = "feels lonely man";

            img[20] = "https://i.imgur.com/LJzEAUi.png";
            name[20] = "feels emotional man";

            img[21] = "https://i.imgur.com/M0MEcQg.png";
            name[21] = "feels god-like man";

            img[22] = "https://i.imgur.com/bivxaHo.png";
            name[22] = "feels prideful man";

            img[23] = "https://i.imgur.com/1AkQlay.png";
            name[23] = "feels cool man";

            img[24] = "https://i.imgur.com/jTaPh6i.png";
            name[24] = "feels good m'lady";

            img[25] = "https://i.imgur.com/hVSaZiC.png";
            name[25] = "feels ok man";

            img[26] = "https://i.imgur.com/EW52xtO.png";
            name[26] = "feels upset man";

            img[26] = "https://i.imgur.com/JygYBBx.png";
            name[26] = "feels lewd man";

            img[27] = "https://i.imgur.com/3yCtMyF.jpg?1";
            name[27] = "feels uneasy man";

            #endregion

            var builder = new EmbedBuilder()
            {
                Color = new Color(0, 180, 0),
                Description = u.Mention + " " + name[pick] //soft hyphen to induce a newline
            };

            builder.ImageUrl = img[pick];

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
        #endregion
        #region Random Facts
        [Command("fact")]
        public async Task fact()
        {
            String[] facts = new String[100];
            Random rnd = new Random();
            int pick = rnd.Next(0, facts.Length);

            #region Facts List
            facts[0] = "Banging your head against a wall burns 150 calories an hour.";
            facts[1] = "In the UK, it is illegal to eat mince pies on Christmas Day!";
            facts[2] = "Pteronophobia is the fear of being tickled by feathers!";
            facts[3] = "When hippos are upset, their sweat turns red.";
            facts[4] = "A flock of crows is known as a murder.";
            facts[5] = "\"Facebook Addiction Disorder\" is a mental disorder identified by Psychologists.";
            facts[6] = "The average woman uses her height in lipstick every 5 years.";
            facts[7] = "Cherophobia is the fear of fun.";
            facts[8] = "Human saliva has a boiling point three times that of regular water.";
            facts[9] = "Billy goats urinate on their own heads to smell more attractive to females.";
            facts[10] = "An eagle can kill a young deer and fly away with it.";
            facts[11] = "Heart attacks are more likely to happen on a Monday.";
            facts[12] = "There is a species of spider called the Hobo Spider.";
            facts[13] = "29th May is officially \"Put A Pillow on Your Fridge Day\".";
            facts[14] = "If you lift a kangaroo’s tail off the ground it can’t hop.";
            facts[15] = "Bananas are curved because they grow towards the sun.";
            facts[16] = "The person who invented the Frisbee was cremated and made into a frisbee after he died!";
            facts[17] = "During your lifetime, you will produce enough saliva to fill two swimming pools.";
            facts[18] = "If Pinocchio says “My Nose Will Grow Now”, it would cause a paradox.";
            facts[19] = "Polar bears can eat as many as 86 penguins in a single sitting (if they lived in the same place).";
            facts[20] = "King Henry VIII slept with a gigantic axe beside him.";
            facts[21] = "Movie trailers were originally shown after the movie, which is why they were called \"trailers\".";
            facts[22] = "If you consistently fart for 6 years & 9 months, enough gas is produced to create the energy of an atomic bomb!";
            facts[23] = "in 2015, more people were killed from injuries caused by taking a selfie than by shark attacks.";
            facts[24] = "The top six foods that make your fart are beans, corn, bell peppers, cauliflower, cabbage and milk!";
            facts[25] = "A lion’s roar can be heard from 5 miles away!";
            facts[26] = "A toaster uses almost half as much energy as a full-sized oven.";
            facts[27] = "A baby spider is called a spiderling.";
            facts[28] = "You cannot snore and dream at the same time.";
            facts[29] = "The following can be read forward and backwards: Do geese see God?";
            facts[30] = "A baby octopus is about the size of a flea when it is born.";
            facts[31] = "A sheep, a duck, and a rooster were the first passengers in a hot air balloon.";
            facts[32] = "In Uganda, 50% of the population is under 15 years of age.";
            facts[33] = "Hitler’s mother considered abortion but the doctor persuaded her to keep the baby.";
            facts[34] = "Arab women can initiate a divorce if their husbands don’t pour coffee for them.";
            facts[35] = "Recycling one glass jar saves enough energy to watch TV for 3 hours.";
            facts[36] = "Catfish are the only animals that naturally have an odd number of whiskers.";
            facts[37] = "Facebook, Skype and Twitter are all banned in China.";
            facts[38] = "95% of people text things they could never say in person.";
            facts[39] = "The Titanic was the first ship to use the SOS signal.";
            facts[40] = "In Poole, \"Pound World\" went out of business because of a store across the road called \"99p Stores\", which was selling the same products but for just 1 pence cheaper!";
            facts[41] = "About 8,000 Americans are injured by musical instruments each year.";
            facts[42] = "The French language has seventeen different words for \"surrender\".";
            facts[43] = "Nearly three percent of the ice in Antarctic glaciers is penguin urine.";
            facts[44] = "Bob Dylan’s real name is Robert Zimmerman.";
            facts[45] = "A crocodile can’t poke its tongue out :p";
            facts[46] = "Sea otters hold hands when they sleep so they don’t drift away from each other.";
            facts[47] = "A small child could swim through the veins of a blue whale.";
            facts[48] = "Bin Laden’s death was announced on 1st May 2011. Hitler’s death was announced on 1st May 1945.";
            facts[49] = "A small child could swim through the veins of a blue whale.";
            facts[50] = "J.K. Rowling chose the unusual name \"Hermione\" so young girls wouldn’t be teased for being nerdy!";
            facts[51] = "Hewlett-Packard’s name was decided in a coin toss.";
            facts[52] = "The total number of steps in the Eiffel Tower are 1665.";
            facts[53] = "The Pokémon Hitmonlee and Hitmonchan are based off of Bruce Lee and Jackie Chan.";
            facts[54] = "An arctophile is a person who collects, or is very fond of teddy bears.";
            facts[55] = "Pirates wore earrings because they believed it improved their eyesight.";
            facts[56] = "Los Angeles’s full name is \"El Pueblo de Nuestra Senora la Reina de los Angeles de Porciuncula.\"";
            facts[57] = "The Twitter bird actually has a name – Larry.";
            facts[58] = "Octopuses have four pairs of arms.";
            facts[59] = "In England, in the 1880’s, \"Pants\" was considered a dirty word.";
            facts[60] = "It snowed in the Sahara desert for 30 minutes on the 18th February 1979.";
            facts[61] = "Every human spent about half an hour as a single cell.";
            facts[62] = "If you leave everything to the last minute… it will only take a minute.";
            facts[63] = "Unlike many other big cats, snow leopards are not aggressive towards humans. There has never been a verified snow leopard attack on a human being.";
            facts[64] = "The first alarm clock could only ring at 4am.";
            facts[65] = "Birds don’t urinate.";
            facts[66] = "Dying is illegal in the Houses of Parliaments – This has been voted as the most ridiculous law by the British citizens.";
            facts[67] = "The most venomous jellyfish in the world is named the Irukandji and is smaller than your fingernail.";
            facts[68] = "The 20th of March is known as Snowman Burning Day.";
            facts[69] = "Slugs have 4 noses.";
            facts[70] = "Panphobia is the fear of everything… which is a pretty unlucky phobia to have.";
            facts[71] = "An apple, potato, and onion all taste the same if you eat them with your nose plugged.";
            facts[72] = "The front paws of a cat are different from the back paws. They have five toes on the front but only four on the back.";
            facts[73] = "A company in Taiwan makes dinnerware out of wheat, so you can eat your plate!";
            facts[74] = "The average person walks the equivalent of twice around the world in a lifetime.";
            facts[75] = "The Bible is the most shoplifted book in the world.";
            facts[76] = "Marco Hort has the world record for fitting 264 straws in his mouth at once!";
            facts[77] = "Mel Blanc – the voice of Bugs Bunny – was allergic to carrots.";
            facts[78] = "California has issued 6 drivers licenses to people named Jesus Christ.";
            facts[79] = "According to Genesis 1:20-22, the chicken came before the egg.";
            facts[80] = "In the Caribbean there are oysters that can climb trees.";
            facts[81] = "Worms eat their own poo.";
            facts[82] = "Squirrels forget where they hide about half of their nuts.";
            facts[83] = "Over 1000 birds a year die from smashing into windows.";
            facts[84] = "The inventor of the Waffle Iron did not like waffles.";
            facts[85] = "George W. Bush was once a cheerleader.";
            facts[86] = "In total, there are 205 bones in the skeleton of a horse.";
            facts[87] = "In 1895 Hampshire police handed out the first ever speeding ticket, fining a man for doing 6mph!";
            facts[88] = "Each year, there are more than 40,000 toilet related injuries in the United States.";
            facts[89] = "Strawberries can also be yellow, green or white. This also affects the taste and some have a similar taste to pineapples.";
            facts[90] = "Mewtwo is a clone of the Pokémon Mew, yet it comes before Mew in the Pokédex.";
            facts[91] = "Every year more than 2500 left-handed people are killed from using right-handed products.";
            facts[92] = "Madonna suffers from garophobia which is the fear of thunder.";
            facts[93] = "In June 2017, the Facebook community reached 2 billion active users. That’s more than a quarter of the world’s population uses Facebook each month.";
            facts[94] = "Samuel L. Jackson requested to have a purple light saber in Star Wars in order for him to accept the part as Mace Windu.";
            facts[95] = "Paraskavedekatriaphobia is the fear of Friday the 13th!";
            facts[96] = "Kleenex tissues were originally used as filters in gas masks.";
            facts[97] = "In 1998, Sony accidentally sold 700,000 camcorders that had the technology to see through people’s clothes. These cameras had special lenses that use infrared light, which allowed you to see through some types of clothing.";
            facts[98] = "During your lifetime, you will spend around thirty-eight days brushing your teeth.";
            facts[99] = "Ronald McDonald is \"Donald McDonald\" in Japan because it makes pronunciation easier for the Japanese. In Singapore he’s known as \"Uncle McDonald\".";
            #endregion

            await Context.Channel.SendMessageAsync(facts[pick]);
        }

        #endregion
        #region RoleMembers
        [Command("members")]
        public async Task whosIn([Remainder] SocketRole r)
        {
            List<string> UserList = new List<string>();
            List<string> UserListSorted = new List<string>();
            var m = r.Members;

            foreach (var v in m)
            {
                string buffer = "";
                string status = "";
                if (v.Status == UserStatus.Offline)
                {
                    status = " |  [OFFLINE]";
                }
                else if (v.Status == UserStatus.Idle)
                {
                    status = " |  [IDLE]";
                }
                else if (v.Status == UserStatus.AFK)
                {
                    status = " |  [AFK]";
                }
                else if (v.Status == UserStatus.DoNotDisturb)
                {
                    status = " |  [DO NOT DISTURB]";
                }
                else if (v.Status == UserStatus.Invisible)
                {
                    status = " |  [INVISIBLE]";
                }
                else
                {
                    status = " |  [ONLINE]";
                }

                if (v.Nickname != "" || v.Nickname != null || v.Nickname != " " || v.Nickname != v.Username)
                {
                    buffer = ", *\"" + v.Nickname + "\"*";
                }
                if (buffer == ", *\"\"*")
                {
                    UserList.Add(v.Username + status);
                }
                else
                {
                    UserList.Add(v.Username + buffer + status);
                }

            }
            UserList.Sort();
            //need a new list to number them in sorted order
            for (int i = 0; i < UserList.Count(); i++)
            {
                UserListSorted.Add(("__**" + (i + 1) + "**__") + ": " + UserList[i] + Environment.NewLine);
            }

            #region Split Array
            List<string[]> splitted = new List<string[]>();//This list will contain all the splitted arrays.
            int lengthToSplit = 25;

            int arrayLength = UserListSorted.Count;

            for (int i = 0; i < arrayLength; i = i + lengthToSplit)
            {
                string[] val = new string[lengthToSplit];

                if (arrayLength < i + lengthToSplit)
                {
                    lengthToSplit = arrayLength - i;
                }
                Array.Copy(UserListSorted.ToArray(), i, val, 0, lengthToSplit);
                splitted.Add(val);
            }


            #endregion
            //embed builder
            if (UserListSorted.Count() > 1)
            {
                await Context.Channel.SendMessageAsync("__**There are " + UserListSorted.Count() + " members in " + r.ToString() + ":**__");
                for (int i = 0; i < splitted.Count; i++)
                {
                    await Context.Channel.SendMessageAsync(Environment.NewLine + Environment.NewLine + string.Join("", splitted[i]));
                }
                return;
            }
            else if (UserListSorted.Count() == 1)
            {
                await Context.Channel.SendMessageAsync("__**There is 1 member in " + r.ToString() + ":**__" + Environment.NewLine + Environment.NewLine + string.Join("", UserListSorted));
                return;
            }
            else
            {
                await Context.Channel.SendMessageAsync("__**There is no one in " + r.ToString() + ":**__");
                return;
            }
        }
        #endregion
        #region Polls
        [Command("poll")]
        public async Task poll([Remainder] string s)
        {
            //[poll help] -> display the help
            //[poll binary Do you like waffles?] -> Sends "__**POLL**__ by___ \n Do you like waffles?" and adds Thumbs up and Thumbs down reactions
            //[poll 3 What's your favourite colour of the three? (1)Red (2)Blue (3)Green] -> Sends the question, then numbers with options and adds nums 1-3 as reactions, MAX 9
            #region Poll Help
            if (s == "help")
            {
                //embed the usual stuff here

                var helper = new EmbedBuilder()
                {
                    Color = new Color(0, 180, 180),
                    Title = "How to use polls: ",
                    Description = "\u00AD" //soft hyphen to induce a newline
                };

                helper.AddField(x =>
                {
                    x.Name = "!poll binary Do you like waffles?";
                    x.Value = "For yes or no questions write `!poll binary` followed by a space, then your question.";
                });

                helper.AddField(x =>
                {
                    x.Name = "!poll 3 What's your preferred gaming platform? (1)PC (2)PS4 (3)XBONE";
                    x.Value = "For multi-choice questions, simply write `!poll ` followed by the number of queries, your question, and format as shown above.";
                });
                await Context.Channel.SendMessageAsync("", false, helper.Build());
                return;
            }
            #endregion
            SocketUser c = Context.User; //grab their name
            var u = c as SocketGuildUser; //' ' ' ' ' ' '
            #region Binary Poll
            if (s.ToLower().StartsWith("binary"))
            {
                //delete the poll start command
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                //send the question
                String question = s.Substring(7); //Cuts off the "binary " part
                if (question.Contains("@everyone") && !u.GuildPermissions.MentionEveryone)
                {
                    question = question.Replace("@everyone", "everyone");
                }

                string name = u.Nickname;
                if (name == "" || name == null)
                {
                    name = u.Username;
                }

                await Context.Channel.SendMessageAsync("__**POLL**__" + Environment.NewLine + "Asked by: " + name + ": ");
                //await Context.Channel.SendMessageAsync("Asked by: " + u.Nickname??u.Username + "): ");
                var msg = await Context.Channel.SendMessageAsync(question); //ask question
                await msg.AddReactionAsync(new Emoji("👍"));
                await msg.AddReactionAsync(new Emoji("👎"));
                return;
            }
            #endregion
            #region Multi Poll
            int count = 0;
            int buffer;
            bool isNum = int.TryParse("" + s[0], out count);
            bool sec = int.TryParse("" + s[1], out buffer);
            Console.WriteLine(count + isNum.ToString() + sec.ToString());
            if (sec || count == 0 || count > 9)
            {
                await Context.Channel.SendMessageAsync(u.Mention + ", poll failed, the range must be within 1-9");
                return;
            }
            if (isNum && !sec)
            {
                //delete the poll start command
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                //send the question
                await Context.Channel.SendMessageAsync("This is WIP.");
                return;
            }
            #endregion
        }
        #endregion
        #region CS Confessions
        [Command("confess")]
        public async Task Confessions([Remainder] string s)
        {
            if (CommandHandler.Glex == null)
            {
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                await Context.Channel.SendMessageAsync("**Oof!** You just confessed in public, some people might have seen that!\nConfessions are currently offline though, try again later and DM it next time.");
                return;
            }

            if (Context.IsPrivate)
            {
                await CommandHandler.Glex.SendMessageAsync("Confession:\n" + s + "\n------END OF CONFESSION------");
                await Context.Channel.SendMessageAsync("Your confession is submitted for human review, thank-you.");
                return;
            }
            else
            {
                await CommandHandler.Glex.SendMessageAsync("Confession:\n" + s + "\n------END OF CONFESSION------");
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                await Context.Channel.SendMessageAsync("**Oof!** You just confessed in public, some people might have seen that!\nNonetheless, your confession is submitted for human review, thank-you. DM it next time.");
                return;
            }

        }
        #endregion
        #region Channel Description
        [Command("desc")]
        public async Task getChanDesc()
        {
            ISocketMessageChannel source = Context.Channel;
            var channel = source as SocketTextChannel;
            await Context.Channel.SendMessageAsync("**" + source.Name + "**:\n" + channel.Topic);
            return;
        }
        #endregion
        #region 8Ball
        [Command("8ball")]
        public async Task eightball([Remainder] string s)
        {
            String[] response = new String[20];
            Random rnd = new Random();
            int pick = rnd.Next(0, response.Length);
            Emoji selected;
            #region Response List
            //good responses:
            response[0] = "It is certain.";
            response[1] = "It is decidedly so.";
            response[2] = "Without a doubt.";
            response[3] = "Yes, definitely.";
            response[4] = "You may rely on it.";
            response[5] = "As I see it, yes.";
            response[6] = "Most likely.";
            response[7] = "Outlook good.";
            response[8] = "Yes.";
            response[9] = "Signs point to yes.";
            //uncertain resposes:
            response[10] = "Reply hazy, try again";
            response[11] = "Ask again later.";
            response[12] = "Better not tell you now.";
            response[13] = "Cannot predict now.";
            response[14] = "Concentrate and ask again.";
            //bad responses:
            response[15] = "Don't count on it.";
            response[16] = "My reply is no.";
            response[17] = "My sources say no.";
            response[18] = "Outlook not so good.";
            response[19] = "Very doubtful.";
            #endregion
            if (pick <= 9)
            {
                selected = new Emoji("📗"); //green book
            }
            else if (pick >= 15)
            {
                selected = new Emoji("📕"); //red book
            }
            else
            {
                selected = new Emoji("📒"); //yellow book
            }
            await Context.Channel.SendMessageAsync(new Emoji("🎱") + " " + s + " " + new Emoji("🎱") + "\n" + "\n" + selected + "| " + response[pick] + " |" + selected);
            return;
        }
        #endregion
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

                    await Context.Channel.SendMessageAsync("", false, builder.Build());

                }

            }
        }
        #endregion
        #region Live Responses Booleans
        [Command("protocol")]
        //[RequireUserPermission(ChannelPermission.ManageMessages)]

        public async Task protocols([Remainder] string s)
        {
            SocketUser sUser = Context.User;
            var user = sUser as SocketGuildUser;

            if (s.ToLower() == "list")
            {
                if (CommandHandler.prtoclN)
                {
                    await Context.Channel.SendMessageAsync("Protocol N: active");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Protocol N: inactive");
                }
            }
            if (s == "N" && user.GuildPermissions.ManageMessages)
            {
                CommandHandler.prtoclN = !CommandHandler.prtoclN;
                if (CommandHandler.prtoclN)
                {
                    await Context.Channel.SendMessageAsync("Protocol N is now enabled.");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Protocol N is now disabled.");
                }
            }
        }
        #endregion
    }
}
