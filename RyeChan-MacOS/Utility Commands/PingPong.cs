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
    public class PingPong : ModuleBase<SocketCommandContext>
    {
        #region Ping-Pong
        [Command("ping")]
        public async Task pingPongMessage()
        {
            await ReplyAsync(Context.User.Mention + $" Pong! {(Context.Client as Discord.WebSocket.DiscordSocketClient).Latency} ms :ping_pong:");
        }
        #endregion
    }
}
