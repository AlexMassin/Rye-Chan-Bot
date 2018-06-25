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
using Newtonsoft.Json.Linq;

namespace RyeChanMacOS.FunCommands
{
    public class UrbanDictionary : ModuleBase<SocketCommandContext>
    {
        #region UD
        [Command("urban")]
        public async Task urbandictionary([Remainder] string s)
        {
            WebClient client = new WebClient();
            client.Headers.Add("X-Mashape-Key", "xqQa0DAlP7mshY18WoUM6t939tEup1lqHQzjsnAVbWo7oTkZeT");
            client.Headers.Add("Accept", "application/json");
            string downloadString = client.DownloadString(new Uri("https://mashape-community-urban-dictionary.p.mashape.com/define?term=" + @s));
            JObject json = JObject.Parse(downloadString);
            if (json["list"].Count() == 0){
                await Context.Channel.SendMessageAsync("There's no definition for that yet!");
                return;
            }
            String word = (string)json["list"][0]["word"];
            String ups = (string)json["list"][0]["thumbs_up"];
            String downs = (string)json["list"][0]["thumbs_down"];
            String example = (string)json["list"][0]["example"];
            String def = (string)json["list"][0]["definition"];
            String link = (string)json["list"][0]["permalink"];

            var result = new EmbedBuilder()
            {
                Color = new Color(30, 37, 57),
                Title = word,
                Description = def,
            };

            if (example.Length > 0 && example != null)
            {
                result.AddField(x =>
                {
                    x.Name = "Example:";
                    x.Value = example;
                });
            }

            result.AddField(x =>
            {
                x.Name = "\u00AD";
                x.Value = ups + "👍 " + downs + "👎";
            });

            result.AddField(x =>
            {
                x.Name = "\u00AD";
                x.Value = "[View More](" + link + ")";
            });

            result.WithFooter("Powered by urbandictionary.com");
            await Context.Channel.SendMessageAsync("", false, result.Build());
        }
        #endregion
    }
}
