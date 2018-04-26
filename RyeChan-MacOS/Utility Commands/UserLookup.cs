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
            await Context.Channel.SendMessageAsync("", false, HelperFunctions.UserData.getData(Context.User as SocketGuildUser).Build());
        }

        [Command("whois")]
        public async Task lookupOthers([Remainder] String s)
        {
            var users = Context.Guild.Users;

            foreach (var u in users)
            {
                if (u.Username == s || u.Nickname == s || u.Mention == s)
                {
                    await Context.Channel.SendMessageAsync("", false, HelperFunctions.UserData.getData(u as SocketGuildUser).Build());
                    //return; //comment out if returning all users with the same name
                }
            }
        }
        #endregion
    }
}
