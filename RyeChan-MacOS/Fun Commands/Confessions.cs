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
    public class Confessions : ModuleBase<SocketCommandContext>
    {
        #region CS Confessions
        [Command("confess")]
        public async Task confessions([Remainder] string s)
        {
            if (CommandHandler.Glex == null)
            {
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                await Context.Channel.SendMessageAsync("**Oof!** You just confessed in public, some people might have seen that!\nConfessions are currently offline though, try again later and DM it next time.");
                return;
            }

            if (Context.IsPrivate)
            {
                await CommandHandler.Glex.SendMessageAsync("Confession:\n" + s + "\n------END OF CONFESSION------");
                await Context.Channel.SendMessageAsync("Your confession is submitted for human review, thank-you.");
                return;
            }
            else
            {
                await CommandHandler.Glex.SendMessageAsync("Confession:\n" + s + "\n------END OF CONFESSION------");
                var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messages);
                await Context.Channel.SendMessageAsync("**Oof!** You just confessed in public, some people might have seen that!\nNonetheless, your confession is submitted for human review, thank-you. DM it next time.");
                return;
            }

        }
        #endregion
        #region Profess
        [Command("profess")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]

        public async Task profess([Remainder] string s)
        {
            var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(messages);

            await Context.Channel.SendMessageAsync("**__Confession #" + CommandHandler.confessionCount + "__**\n" + s);
            using (StreamWriter sw = new StreamWriter("ConfessionCounter.key", false))
            {
                sw.WriteLine(CommandHandler.confessionCount++);
            }
            CommandHandler.confessionCount++;
        }
        #endregion
    }
}
