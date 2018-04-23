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
    public class ProtocolSuper : ModuleBase<SocketCommandContext>
    {
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
