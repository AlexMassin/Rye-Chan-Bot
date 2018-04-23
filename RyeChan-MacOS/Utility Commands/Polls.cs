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
    public class Polls : ModuleBase<SocketCommandContext>
    {
        #region Polls
        [Command("poll")]
        public async Task poll([Remainder] string s)
        {
            //[poll help] -> display the help
            //[poll binary Do you like waffles?] -> Sends "__**POLL**__ by___ \n Do you like waffles?" and adds Thumbs up and Thumbs down reactions
            //[poll 3 What's your favourite colour of the three? (1)Red (2)Blue (3)Green] -> Sends the question, then numbers with options and adds nums 1-3 as reactions, MAX 9
            #region Poll Help
            if (s == "help")
            {
                //embed the usual stuff here

                var helper = new EmbedBuilder()
                {
                    Color = new Color(0, 180, 180),
                    Title = "How to use polls: ",
                    Description = "\u00AD" //soft hyphen to induce a newline
                };

                helper.AddField(x =>
                {
                    x.Name = "!poll binary Do you like waffles?";
                    x.Value = "For yes or no questions write `!poll binary` followed by a space, then your question.";
                });

                helper.AddField(x =>
                {
                    x.Name = "!poll 3 What's your preferred gaming platform? (1)PC (2)PS4 (3)XBONE";
                    x.Value = "For multi-choice questions, simply write `!poll ` followed by the number of queries, your question, and format as shown above.";
                });
                await Context.Channel.SendMessageAsync("", false, helper.Build());
                return;
            }
            #endregion
            SocketUser c = Context.User; //grab their name
            var u = c as SocketGuildUser; //' ' ' ' ' ' '
            #region Binary Poll
            if (s.ToLower().StartsWith("binary"))
            {
                //delete the poll start command
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                //send the question
                String question = s.Substring(7); //Cuts off the "binary " part
                if (question.Contains("@everyone") && !u.GuildPermissions.MentionEveryone)
                {
                    question = question.Replace("@everyone", "everyone");
                }

                string name = u.Nickname;
                if (name == "" || name == null)
                {
                    name = u.Username;
                }

                await Context.Channel.SendMessageAsync("__**POLL**__" + Environment.NewLine + "Asked by: " + name + ": ");
                //await Context.Channel.SendMessageAsync("Asked by: " + u.Nickname??u.Username + "): ");
                var msg = await Context.Channel.SendMessageAsync(question); //ask question
                await msg.AddReactionAsync(new Emoji("👍"));
                await msg.AddReactionAsync(new Emoji("👎"));
                return;
            }
            #endregion
            #region Multi Poll
            int count = 0;
            int buffer;
            bool isNum = int.TryParse("" + s[0], out count);
            bool sec = int.TryParse("" + s[1], out buffer);
            Console.WriteLine(count + isNum.ToString() + sec.ToString());
            if (sec || count == 0 || count > 9)
            {
                await Context.Channel.SendMessageAsync(u.Mention + ", poll failed, the range must be within 1-9");
                return;
            }
            if (isNum && !sec)
            {
                //delete the poll start command
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                //send the question
                await Context.Channel.SendMessageAsync("This is WIP.");
                return;
            }
            #endregion
        }
        #endregion
    }
}
