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

namespace RyeChanMacOS.FunCommands
{
    public class xkcd : ModuleBase<SocketCommandContext>
    {
        #region xkcd Comics
        [Command("xkcd")]
        public async Task comics()
        {
            Random rnd = new Random();
            //as of 5/15/18, 1993 is the max
            var result = new EmbedBuilder()
            {
                Color = new Color(152, 0, 255),
                Description = Context.User.Mention + " is craving some comics!",
                ImageUrl = HelperFunctions.glexStringLib.substringBetween(new WebClient().DownloadString("https://xkcd.com/" + rnd.Next(1, 1994) + "/info.0.json"), "\"img\": \"", "\", \"title\":"),
            };
            result.WithFooter("Powered by xkcd.com");
            await Context.Channel.SendMessageAsync("", false, result.Build());
        }
        #endregion
    }
}
