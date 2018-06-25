using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using RyeChan_MacOS;

namespace RyeChanMacOS.UtilityCommands
{
    public class LaTeX : ModuleBase<SocketCommandContext>
    {
        #region LaTeX
        [Command("tex")]
        public async Task latex([Remainder] string s)
        {
            if (CommandHandler.escFirstChar) s = "\\" + s;
            var result = new EmbedBuilder()
            {
                Color = new Color(255, 155, 15),
                Description = "LaTeX Generator",
                ImageUrl = new UriBuilder(new Uri("https://latex.codecogs.com/png.latex?\\color{white}" + @s)).ToString()
            };
            result.WithFooter("Powered by latex.codecogs.com");
            await Context.Channel.SendMessageAsync("", false, result.Build());
        }
        #endregion
    }
}
