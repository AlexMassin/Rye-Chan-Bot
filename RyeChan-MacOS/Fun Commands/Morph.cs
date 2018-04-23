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
    public class Morph : ModuleBase<SocketCommandContext>
    {
        #region Morph
        [Command("morph")]
        public async Task morph(String a, String b)
        {
            String op = "";
            a = a.Trim();
            b = b.Trim();

            a = a.Replace("@", "\\@");
            b = b.Replace("@", "\\@");

            int start = 2;

            a = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(a);
            b = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(b);

            if (a[0] != b[0])
            {
                start = 1;
            }

            op += a.Substring(0, a.Length);

            for (int i = a.Length - 1; i >= 0; i--)
            {
                op += Environment.NewLine + a.Substring(0, i);
            }

            for (int i = start; i <= b.Length; i++)
            {
                op += b.Substring(0, i) + Environment.NewLine;
            }
            await Context.Channel.SendMessageAsync(op);
            return;
        }
        #endregion
    }
}
