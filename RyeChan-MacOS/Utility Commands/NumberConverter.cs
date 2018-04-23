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
    public class NumberConverter : ModuleBase<SocketCommandContext>
    {
        #region Number Converter
        [Command("conv")]
        public async Task convertNumber(string numb, params string[] s)
        {
            string op = "";
            Int64 num = -1;

            try
            {
                num = Convert.ToInt64(numb);
                if (num < 0)
                {
                    await Context.Channel.SendMessageAsync("Sorry dude, can't do negatives yet, in the future maybe.");
                    return;
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Caught " + x);
            }
            s[0] = s[0].ToLower();
            s[2] = s[2].ToLower();

            //Determine what the conversion is from and to

            //Start with BEAN cases
            if (numb == "0" || num == 0)
            {
                await Context.Channel.SendMessageAsync("Hahah, nice try dude, converting 0....");
                return;
            }
            else if (s[0] == s[2] && (s[0] == "dec" || s[0] == "bin" || s[0] == "oct" || s[0] == "hex"))
            {
                await Context.Channel.SendMessageAsync("Do you think I'm a bean?");
                return;
            }
            //Start with hex first cuz it's the only one that needs to start as string
            else if (s[0] == "hex" && s[2] == "dec")
            {
                //From HEX to DEC
                await Context.Channel.SendMessageAsync("Converting " + numb + " from HEX to DEC:");
                op = Convert.ToString(Convert.ToInt64(numb, 16), 10);
            }
            else if (s[0] == "hex" && s[2] == "bin")
            {
                //From HEX to BIN
                await Context.Channel.SendMessageAsync("Converting " + numb + " from HEX to BIN:");
                op = Convert.ToString(Convert.ToInt64(numb, 16), 2);
            }
            else if (s[0] == "hex" && s[2] == "oct")
            {
                //From HEX to OCT
                await Context.Channel.SendMessageAsync("Converting " + numb + " from HEX to OCT:");
                op = Convert.ToString(Convert.ToInt64(numb, 16), 8);
            }
            else if (s[0] == "dec" && s[2] == "bin")
            {
                //From DEC to BIN
                await Context.Channel.SendMessageAsync("Converting " + num + " from DEC to BIN:");
                op = Convert.ToString(num, 2);
            }
            else if (s[0] == "dec" && s[2] == "oct")
            {
                //From DEC to OCT
                await Context.Channel.SendMessageAsync("Converting " + num + " from DEC to OCT:");
                op = Convert.ToString(num, 8);
            }
            else if (s[0] == "dec" && s[2] == "hex")
            {
                //From DEC to HEX
                await Context.Channel.SendMessageAsync("Converting " + num + " from DEC to HEX:");
                op = Convert.ToString(num, 16);
            }
            else if (s[0] == "bin" && s[2] == "dec")
            {
                //From BIN to DEC
                await Context.Channel.SendMessageAsync("Converting " + num + " from BIN to DEC:");
                op = Convert.ToInt64(num.ToString(), 2).ToString();
            }
            else if (s[0] == "bin" && s[2] == "oct")
            {
                //From BIN to OCT
                await Context.Channel.SendMessageAsync("Converting " + num + " from BIN to OCT:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 2);
                op = Convert.ToString(buffer, 8);
            }
            else if (s[0] == "bin" && s[2] == "hex")
            {
                //From BIN to HEX
                await Context.Channel.SendMessageAsync("Converting " + num + " from BIN to HEX:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 2);
                op = Convert.ToString(buffer, 16);
            }
            else if (s[0] == "oct" && s[2] == "dec")
            {
                //From OCT to DEC
                await Context.Channel.SendMessageAsync("Converting " + num + " from OCT to DEC:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 8);
                op = Convert.ToString(buffer, 10);
            }
            else if (s[0] == "oct" && s[2] == "bin")
            {
                //From OCT to BIN
                await Context.Channel.SendMessageAsync("Converting " + num + " from OCT to BIN:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 8);
                op = Convert.ToString(buffer, 2);
            }
            else if (s[0] == "oct" && s[2] == "hex")
            {
                //From OCT to HEX
                await Context.Channel.SendMessageAsync("Converting " + num + " from OCT to HEX:");
                Int64 buffer = Convert.ToInt64(num.ToString(), 8);
                op = Convert.ToString(buffer, 16);
            }

            if (op != "")
            {
                await Context.Channel.SendMessageAsync(op);
            }
            else if (s[2] != "dec" || s[2] != "bin" || s[2] != "oct" || s[2] != "hex")
            {
                await Context.Channel.SendMessageAsync("My dude, " + s[2] + " is not a valid type of base.");
            }
            else if (s[0] != "dec" || s[0] != "bin" || s[0] != "oct" || s[0] != "hex")
            {
                await Context.Channel.SendMessageAsync("My dude, " + s[0] + " is not a valid type of base.");
            }
            else if (op == "0" && numb != "0")
            {
                await Context.Channel.SendMessageAsync("Oh jeez, looks like I ran into a problem, your input: " + numb + "seems to have caused an error.");
                await Context.Channel.SendMessageAsync("Please contact my Alex.");
            }
            else
            {
                await Context.Channel.SendMessageAsync("Oh jeez, looks like I ran into a unknown problem, contact Alex please.");
            }

        }
        #endregion
    }
}
