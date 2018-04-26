using System;
using Discord;
using Discord.WebSocket;

namespace RyeChanMacOS.HelperFunctions
{
    public class Avatar
    {
        public static string getAvatar(SocketGuildUser u)
        {
            string link = "";
            if (u.AvatarId != null && u.AvatarId.StartsWith("a_")) link = u.GetAvatarUrl(ImageFormat.Gif, 1024);
            else link = u.GetAvatarUrl(ImageFormat.Png, 1024);
            if (link == "" || link == null)
            {
                link = $"{DiscordConfig.CDNUrl}embed/avatars/{u.DiscriminatorValue % 5}.png";
            }
            return link;
        }
        public static string getAvatar(SocketUser u)
        {
            string link = "";
            if (u.AvatarId != null && u.AvatarId.StartsWith("a_")) link = u.GetAvatarUrl(ImageFormat.Gif, 1024);
            else link = u.GetAvatarUrl(ImageFormat.Png, 1024);
            if (link == "" || link == null)
            {
                link = $"{DiscordConfig.CDNUrl}embed/avatars/{u.DiscriminatorValue % 5}.png";
            }
            return link;
        }
    }
}
