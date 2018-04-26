using System;
using Discord.WebSocket;

namespace RyeChanMacOS.HelperFunctions
{
    public class UserStatus
    {
        public static string getStatus(SocketGuildUser u)
        {
            if (u.Status == Discord.UserStatus.Offline)
            {
                return "Offline";
            }
            else if (u.Status == Discord.UserStatus.Idle)
            {
                return "Idle";
            }
            else if (u.Status == Discord.UserStatus.AFK)
            {
                return "Afk";
            }
            else if (u.Status == Discord.UserStatus.DoNotDisturb)
            {
                return "Do Not Disturb";
            }
            else if (u.Status == Discord.UserStatus.Invisible)
            {
                return "Invisible";
            }
            else if (u.Status == Discord.UserStatus.Online)
            {
                return "Online";
            }
            return "Unknown"; //should never occur unless there's some error
        }
    }
}
