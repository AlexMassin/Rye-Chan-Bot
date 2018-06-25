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
    public class Quote : ModuleBase<SocketCommandContext>
    {
        #region Quote
        [Command("quote")]
        public async Task quote(ulong id)
        {
            await Context.Message.DeleteAsync();
            var msg = await Context.Channel.GetMessagesAsync(100).Flatten();
            String content = "";
            String author = "";
            String avatar = "";
            String time = "";

            foreach (var u in msg){
                if (u.Id == id)
                {
                    content = "\"" + u.Content + "\"";
                    author = HelperFunctions.ProperName.getName(u.Author as SocketUser);
                    avatar = HelperFunctions.Avatar.getAvatar(u.Author as SocketUser);
                    time = HelperFunctions.DateFormat.getFormatted(u.Timestamp);
                    break;
                }
            }

            if (content.Length == 0)
            {
                var m = await Context.Channel.SendMessageAsync("Couldn't find the message.");
                await Task.Delay(5000);
                await m.DeleteAsync();
            }
            else
            {
                var result = new EmbedBuilder();
                result.WithAuthor(author, avatar);
                result.WithDescription(content);
                result.WithColor(new Color(66, 217, 244));
                result.WithFooter(time);
                await Context.Channel.SendMessageAsync("", false, result.Build());
            }
        }
        #endregion
    }
}
