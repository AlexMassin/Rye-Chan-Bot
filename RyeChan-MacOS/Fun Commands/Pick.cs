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
    public class Pick : ModuleBase<SocketCommandContext>
    {
        #region Pick
        [Command("pick")]
        public async Task pick([Remainder] String s)
        {
            List<String> choices = @s.Split(",").ToList();

            for (int i = 0; i < choices.Count; i++)
            {
                String chc = choices[i];
                if (string.IsNullOrWhiteSpace(choices[i]))
                {
                    choices.RemoveAt(i);
                    i--;
                    continue;
                }
                choices[i] = choices[i].Trim();
            }
            if (choices.Count == 0)
            {
                await Context.Channel.SendMessageAsync("Doesn't look like there were any valid choices.");
                return;
            }
            if (choices.Count == 1)
            {
                await Context.Channel.SendMessageAsync(@"Well, there was only one choice so... I picked " + choices[0]);
                return;
            }
            else
            {
                Random rng = new Random();
                await Context.Channel.SendMessageAsync(@"I picked: " + choices[rng.Next(0, choices.Count)]);
                return;
            }
        }
        #endregion
    }
}
