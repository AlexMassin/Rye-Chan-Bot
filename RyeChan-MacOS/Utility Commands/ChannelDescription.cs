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
    public class ChannelDescription : ModuleBase<SocketCommandContext>
    {
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
    }
}
