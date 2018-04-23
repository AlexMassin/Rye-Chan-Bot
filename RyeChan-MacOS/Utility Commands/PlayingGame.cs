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
    public class PlayingGame : ModuleBase<SocketCommandContext>
    {
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
    }
}
