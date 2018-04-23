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
    public class Mock : ModuleBase<SocketCommandContext>
    {
        #region Mock
        [Command("mock")]
        public async Task mockMessage([Remainder] string s)
        {
            //Delete command message
            var messages = await Context.Channel.GetMessagesAsync(1).Flatten();

            await Context.Channel.DeleteMessagesAsync(messages);

            SocketUser sUser = Context.User;
            var user = sUser as SocketGuildUser;

            if (s.Contains("@everyone") && !user.GuildPermissions.MentionEveryone)
            {
                s = s.Replace("@everyone", "everyone");
            }

            s = s.ToLower();

            string toOutput = "";
            char[] c = s.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (i % 2 == 0)
                {
                    char buffer = c[i];
                    c[i] = char.ToUpper(c[i]);
                }
                toOutput += c[i];
            }


            if (toOutput != "")
            {
                await Context.Channel.SendMessageAsync(toOutput);
            }
            else
            {
                await Context.Channel.SendMessageAsync("What do you want me to mock?");
            }

        }
        #endregion
    }
}
