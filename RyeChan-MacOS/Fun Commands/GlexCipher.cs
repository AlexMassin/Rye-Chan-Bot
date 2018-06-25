using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
namespace RyeChanMacOS.FunCommands
{
    public class GlexCipher : ModuleBase<SocketCommandContext>
    {
        #region Encrpyt
        [Command("encrypt")]
        public async Task encrypt([Remainder] String s)
        {
            bool show = false; //set to false when not debugging
            String key = "";
            String message = "";
            var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(messages);
            if (!s.Contains("key="))
            {
                await Context.Channel.SendMessageAsync("Missing key!");
                return;
            }
            else
            {
                String[] words = s.Split("key=");
                message = words[0].Trim();
                words[0] = "";
                key = String.Join("", words).Split(" ")[0].Trim().ToLower();
                if (HelperFunctions.GlexEncryption.isInvalidKey(key))
                {
                    await Context.Channel.SendMessageAsync("The key must only be alphabetical.");
                    return;
                }
                if (show) await Context.Channel.SendMessageAsync("Message=" + message + "\nKey=" + key);
            }
            //grabbed message and key
            message = HelperFunctions.GlexEncryption.ninesComp(message);
            if (show) await Context.Channel.SendMessageAsync("1: " + message);
            message = HelperFunctions.GlexEncryption.reverseOdds(message);
            if (show) await Context.Channel.SendMessageAsync("2: " + message);
            message = HelperFunctions.GlexEncryption.digitalRoot(message);
            if (show) await Context.Channel.SendMessageAsync("3: " + message);
            message = HelperFunctions.GlexEncryption.VigenereEncrpyt(message, key);
            if (show) await Context.Channel.SendMessageAsync("4: " + message);
            message = HelperFunctions.GlexEncryption.reverseAll(message);
            await Context.Channel.SendMessageAsync(message + "\n\nFrom: " + Context.User.Mention);
        }
        #endregion
        #region Decrypt
        [Command("decrypt")]
        public async Task decrypt([Remainder] String s)
        {
            bool show = false;
            String key = "";
            String message = "";
            var messages = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(messages);
            if (!s.Contains("key="))
            {
                await Context.Channel.SendMessageAsync("Missing key!");
                return;
            }
            else
            {
                String[] words = s.Split("key=");
                message = words[0].Trim();
                words[0] = "";
                key = String.Join("", words).Split(" ")[0].Trim().ToLower();
                if (HelperFunctions.GlexEncryption.isInvalidKey(key))
                {
                    await Context.Channel.SendMessageAsync("The key must only be alphabetical.");
                    return;
                }
                if (show) await Context.Channel.SendMessageAsync("Message=" + message + "\nKey=" + key);
            }
            //grabbed message and key
            message = HelperFunctions.GlexEncryption.reverseAll(message);
            if (show) await Context.Channel.SendMessageAsync("1: " + message);
            message = HelperFunctions.GlexEncryption.VigenereDecrpyt(message, key);
            if (show) await Context.Channel.SendMessageAsync("2: " + message);
            message = HelperFunctions.GlexEncryption.reverseOdds(message);
            if (show) await Context.Channel.SendMessageAsync("3: " + message);
            message = HelperFunctions.GlexEncryption.digitalSquare(message);
            if (show) await Context.Channel.SendMessageAsync("4: " + message);
            message = HelperFunctions.GlexEncryption.revertNinesComp(message);
            if (show) await Context.Channel.SendMessageAsync(message);
            else await Context.User.SendMessageAsync("Decrypted:\n\n" + message);
        }
        #endregion
    }
}
