using System;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace RyeChanMacOS.FunCommands
{
    public class InspiroBot : ModuleBase<SocketCommandContext>
    {
        #region Get Random InspiroBot Pic
        [Command("inspiro")]
        public async Task inspiro()
        {
            var result = new EmbedBuilder()
            {
                Color = new Color(0, 180, 0),
                Description = Context.User.Mention + " needed a little inspiration.",
                ImageUrl = new WebClient().DownloadString("http://inspirobot.me/api?generate=true"),
            };
            result.WithFooter("Powered by inspirobot.me");
            await Context.Channel.SendMessageAsync("", false, result.Build());
        }
        #endregion
    }
}
