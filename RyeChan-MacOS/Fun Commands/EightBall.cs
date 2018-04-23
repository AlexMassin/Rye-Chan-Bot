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
    public class EightBall : ModuleBase<SocketCommandContext>
    {
        #region 8Ball
        [Command("8ball")]
        public async Task eightball([Remainder] string s)
        {
            String[] response = new String[20];
            Random rnd = new Random();
            int pick = rnd.Next(0, response.Length);
            Emoji selected;
            #region Response List
            //good responses:
            response[0] = "It is certain.";
            response[1] = "It is decidedly so.";
            response[2] = "Without a doubt.";
            response[3] = "Yes, definitely.";
            response[4] = "You may rely on it.";
            response[5] = "As I see it, yes.";
            response[6] = "Most likely.";
            response[7] = "Outlook good.";
            response[8] = "Yes.";
            response[9] = "Signs point to yes.";
            //uncertain resposes:
            response[10] = "Reply hazy, try again";
            response[11] = "Ask again later.";
            response[12] = "Better not tell you now.";
            response[13] = "Cannot predict now.";
            response[14] = "Concentrate and ask again.";
            //bad responses:
            response[15] = "Don't count on it.";
            response[16] = "My reply is no.";
            response[17] = "My sources say no.";
            response[18] = "Outlook not so good.";
            response[19] = "Very doubtful.";
            #endregion
            if (pick <= 9)
            {
                selected = new Emoji("📗"); //green book
            }
            else if (pick >= 15)
            {
                selected = new Emoji("📕"); //red book
            }
            else
            {
                selected = new Emoji("📒"); //yellow book
            }
            await Context.Channel.SendMessageAsync(new Emoji("🎱") + " " + s + " " + new Emoji("🎱") + "\n" + "\n" + selected + "| " + response[pick] + " |" + selected);
            return;
        }
        #endregion
    }
}
