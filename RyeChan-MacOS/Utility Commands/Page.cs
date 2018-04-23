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
    public class Page : ModuleBase<SocketCommandContext>
    {
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
    }
}
