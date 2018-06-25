using System;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;

namespace RyeChanMacOS.FunCommands
{
    public class DadJokes : ModuleBase<SocketCommandContext>
    {
        #region Dad Jokes
        [Command("dadjoke")]
        public async Task dadJokes()
        {
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/json");
            string downloadString = client.DownloadString("https://icanhazdadjoke.com/");
            JObject json = JObject.Parse(downloadString);
            var result = new EmbedBuilder()
            {
                Color = new Color(144, 212, 192),
                Description = (string)json["joke"],
            };
            result.WithFooter("Powered by icanhazdadjoke.com");
            await Context.Channel.SendMessageAsync("", false, result.Build());
        }
        #endregion
        }
}
