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
        public async Task morph([Remainder] String s)
        {
            String op = "";
            String[] words = s.Split(" ");
            String a = words[0].Trim();
            String b = words[1].Trim();
            int length = 0; //determine if char length exceeds 2k

            for (int i = 0; i < a.Length - 1; i++) length += a.Length - i;
            for (int i = 0; i < b.Length - 1; i++) length += b.Length - i;

            if (length >= 1999) {
                await Context.Channel.SendMessageAsync("Message is too long, shorten your morph words!");
                return;
            }

            a = Regex.Replace(a, "[@\"]", "");
            b = Regex.Replace(b, "[@\"]", "");
            a = a[0].ToString().ToUpper() + a.Substring(1);
            b = b[0].ToString().ToUpper() + b.Substring(1);

            int start = 2;

            if (a[0] != b[0])
            {
                start = 1;
                length++;
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
