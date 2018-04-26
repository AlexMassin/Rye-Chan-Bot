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

namespace RyeChanMacOS.FunCommands
{
    public class Say : ModuleBase<SocketCommandContext>
    {
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
    }
}
