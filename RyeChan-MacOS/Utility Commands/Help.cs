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
    public class Help : ModuleBase<SocketCommandContext>
    {
        #region Help
        [Command("help")]
        public async Task helpMessage()
        {
            var builder = new EmbedBuilder()
            {
                Color = new Color(255, 223, 0),
                Title = "Here is what you can do with Rye High Bot: ",
                Description = "\u00AD" //soft hyphen to induce a newline
            };

            builder.AddField(x =>
            {
                x.Name = "!about";
                x.Value = "General information." + Environment.NewLine;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "!say {message}";
                x.Value = "Says your message." + Environment.NewLine;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "!mock {message}";
                x.Value = "Mocks your message." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!pick {Choice 1, Choice 2, Choice 3.... etc}";
                x.Value = "Picks one of your choices randomly." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!ping";
                x.Value = "Returns the latency of the bot's response." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!trim {1 < count < 99}";
                x.Value = "Deletes a count number of numbers [REQUIRES MM PERMS]." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!conv {num} {baseA} to {baseB}";
                x.Value = "Converts num from baseA to baseB [DEC/BIN/OCT/HEX only]." + Environment.NewLine;
            });

            builder.AddField(x =>
            {
                x.Name = "!playing {game} {override name}";
                x.Value = "Shows and lists [a-z] how many members are currently playing a game." + Environment.NewLine + "Adding {override name} at the end will force the name (no shortcut).";
            });

            builder.AddField(x =>
            {
                x.Name = "!members {role}";
                x.Value = "Shows and lists [a-z] how many members are in a role.";
            });

            builder.AddField(x =>
            {
                x.Name = "!avatar {username/nickname}";
                x.Value = "Gives you the URL of someone's avatar.";
            });

            builder.AddField(x =>
            {
                x.Name = "!desc";
                x.Value = "Gives you the channel's description.";
            });

            builder.AddField(x =>
            {
                x.Name = "!whois {username/nickname}";
                x.Value = "Gives you details about the user's account. Leave blank for info about yourself.";
            });

            builder.AddField(x =>
            {
                x.Name = "!feels";
                x.Value = "Gives you a random dank pepe.";
            });

            builder.AddField(x =>
            {
                x.Name = "!8ball {Yes or no question}";
                x.Value = "Acts like a Magic 8-Ball so ask it yes or no questions.";
            });

            builder.AddField(x =>
            {
                x.Name = "!fact";
                x.Value = "Gives you a random fun fact.";
            });

            builder.AddField(x =>
            {
                x.Name = "!confess {yourConfession, your biological sex}";
                x.Value = "Sends your confession for filtering and is posted anonymously.";
            });

            builder.AddField(x =>
            {
                x.Name = "!morph {firstWord} {secondWord}";
                x.Value = "Morphs the first word into the second word.";
            });

            builder.AddField(x =>
            {
                x.Name = "!poll help";
                x.Value = "Gives a help page for polls.";
            });

            builder.AddField(x =>
            {
                x.Name = "!page";
                x.Value = "Pushes chat up. Use this when something uncomfortable is in direct view [REQUIRES MM PERMS].";
            });

            builder.AddField(x =>
            {
                x.Name = "!protocol {[X]/list}";
                x.Value = "Entering list gives the list of protocols and entering [X] will toggle the activation status of [X] protocol.";
            });

            //END HERE

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
        #endregion
    }
}
