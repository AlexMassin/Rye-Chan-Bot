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
using System.Net;

namespace RyeChanMacOS.UtilityCommands
{
    public class Talk : ModuleBase<SocketCommandContext>
    {
        #region Talk
        [Command("ttr")]
        public async Task talk([Remainder] String s)
        {
            WebClient client = new WebClient();
            s = Regex.Replace(s, "[+]", "%2B");
            string downloadString = client.DownloadString("https://www.botlibre.com/rest/api/form-chat?" +
                                                          "&application=2242613879942469750" +
                                                          "&instance=22153138" +
                                                          "&message="+@s);
            String result = HelperFunctions.glexStringLib.substringBetween(downloadString, "<message>", "</message>");
            result = Regex.Replace(result, "&lt;br/&gt;", "\n").Trim(); //jQuery -> high level
            await Context.Channel.SendMessageAsync(result);
        }
        #endregion
    }
}
