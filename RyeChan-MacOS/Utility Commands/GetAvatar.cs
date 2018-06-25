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
                    string name = HelperFunctions.ProperName.getName(u);
                    String link = HelperFunctions.Avatar.getAvatar(u);
                    var result = new EmbedBuilder()
                    {
                        Color = new Color(3, 129, 255),
                        Description = name + "'s avatar: [[Link]](" + link + ")",
                        ImageUrl = link
                    };
                    await Context.Channel.SendMessageAsync("", false, result.Build());
                    //return; //comment out if returning all cases
                }
            }
        }
        [Command("avatar")]
        public async Task getAvatarSelf()
        {
            string name = HelperFunctions.ProperName.getName(Context.User);
            String link = HelperFunctions.Avatar.getAvatar(Context.User);
            var result = new EmbedBuilder()
            {
                Color = new Color(3, 129, 255),
                Description = name + "'s avatar: [[Link]](" + link + ")",
                ImageUrl = link
            };
            await Context.Channel.SendMessageAsync("", false, result.Build());
        }
        #endregion
    }
}
