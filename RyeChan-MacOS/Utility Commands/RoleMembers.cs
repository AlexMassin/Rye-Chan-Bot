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
    public class RoleMembers : ModuleBase<SocketCommandContext>
    {
        #region RoleMembers
        [Command("members")]
        public async Task whosIn([Remainder] SocketRole r)
        {
            List<string> UserList = new List<string>();
            List<string> UserListSorted = new List<string>();
            var m = r.Members;

            foreach (var v in m)
            {
                string buffer = "";
                string status = " |   [" + HelperFunctions.UserStatus.getStatus(v).ToUpper() + "]";

                if (v.Nickname != "" || v.Nickname != null || v.Nickname != " " || v.Nickname != v.Username)
                {
                    buffer = ", *\"" + v.Nickname + "\"*";
                }
                if (buffer == ", *\"\"*")
                {
                    UserList.Add(v.Username + status);
                }
                else
                {
                    UserList.Add(v.Username + buffer + status);
                }

            }
            UserList.Sort();
            //need a new list to number them in sorted order
            for (int i = 0; i < UserList.Count(); i++)
            {
                UserListSorted.Add(("__**" + (i + 1) + "**__") + ": " + UserList[i] + Environment.NewLine);
            }

            #region Split Array
            List<string[]> splitted = new List<string[]>();//This list will contain all the splitted arrays.
            int lengthToSplit = 25;

            int arrayLength = UserListSorted.Count;

            for (int i = 0; i < arrayLength; i = i + lengthToSplit)
            {
                string[] val = new string[lengthToSplit];

                if (arrayLength < i + lengthToSplit)
                {
                    lengthToSplit = arrayLength - i;
                }
                Array.Copy(UserListSorted.ToArray(), i, val, 0, lengthToSplit);
                splitted.Add(val);
            }


            #endregion
            //embed builder
            if (UserListSorted.Count() > 1)
            {
                await Context.Channel.SendMessageAsync("__**There are " + UserListSorted.Count() + " members in " + r.ToString() + ":**__");
                for (int i = 0; i < splitted.Count; i++)
                {
                    await Context.Channel.SendMessageAsync(Environment.NewLine + Environment.NewLine + string.Join("", splitted[i]));
                }
                return;
            }
            else if (UserListSorted.Count() == 1)
            {
                await Context.Channel.SendMessageAsync("__**There is 1 member in " + r.ToString() + ":**__" + Environment.NewLine + Environment.NewLine + string.Join("", UserListSorted));
                return;
            }
            else
            {
                await Context.Channel.SendMessageAsync("__**There is no one in " + r.ToString() + ":**__");
                return;
            }
        }
        #endregion
    }
}
