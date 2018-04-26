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
    public class GetAvatar : ModuleBase<SocketCommandContext>
    {
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
                    await Context.Channel.SendMessageAsync(name + "'s avatar: " + Environment.NewLine + HelperFunctions.Avatar.getAvatar(u));
                    //return; //comment out if returning all cases
                }
            }
        }
        [Command("avatar")]
        public async Task getAvatarSelf()
        {
            await Context.Channel.SendMessageAsync(Context.User.Username + "'s avatar: " + Environment.NewLine + HelperFunctions.Avatar.getAvatar(Context.User));
        }
        #endregion
    }
}
