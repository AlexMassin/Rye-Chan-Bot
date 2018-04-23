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
    public class About : ModuleBase<SocketCommandContext>
    {
        #region About
        [Command("about")]
        public async Task about()
        {
            await Context.Channel.SendMessageAsync("This is a bot written by Alex Gomes in C# (.NET Core) with the Discord API.\n\nThis bot is dedicated to the Comp Sci Gang Discord server.\n\nIt is currently being worked on here and there with improvements, updates, and features.\n\nIf there's a feature you'd like to see added or a bug to fix, please DM or mention " +
                "Alex Gomes, `@GlexAomes#9999`.\n\nSpecial thanks to Judah for creating the server and my two helpful testers, Tony and Ethan.\n" +
                "V2.60_121a MacOS");
        }
        #endregion
    }
}
