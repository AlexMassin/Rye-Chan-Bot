using System;
using Discord.WebSocket;

namespace RyeChanMacOS.HelperFunctions
{
    public class ProperName
    {
        public static String getName(SocketGuildUser u)
        {
            String name = u.Nickname;
            if (u.Nickname == "" || u.Nickname == null)
            {
                name = u.Username;
            }
            return name;
        }

        public static String getName(SocketUser u)
        {
            SocketGuildUser v = u as SocketGuildUser;
            String name = v.Nickname;
            if (v.Nickname == "" || v.Nickname == null)
            {
                name = v.Username;
            }
            return name;
        }
    }
}
