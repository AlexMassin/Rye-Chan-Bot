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
    public class Trim : ModuleBase<SocketCommandContext>
    {
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
    }
}
