using System;
using Discord;
using Discord.WebSocket;

namespace RyeChanMacOS.HelperFunctions
{
    public class UserData
    {
        public static EmbedBuilder getData(SocketGuildUser u)
        {
            String username = u.Username;
            String nickname = u.Nickname;
            if (nickname == "" || nickname == null) nickname = "NO NICKNAME";
            String playing = u.Game.ToString();
            if (playing == "" || playing == null) playing = "NOT PLAYING ANYTHING CURRENTLY";
            String created = HelperFunctions.DateFormat.getFormatted(u.CreatedAt);
            String avatarURL = HelperFunctions.Avatar.getAvatar(u);
            String status = HelperFunctions.UserStatus.getStatus(u);
            String id = u.Id.ToString();
            String discriminator = u.Discriminator;
            String joined = HelperFunctions.DateFormat.getFormatted((DateTimeOffset)u.JoinedAt);
            var builder = new EmbedBuilder()
            {
                Color = new Color(0, 0, 0),
                Title = "Username: ",
                Description = username //soft hyphen to induce a newline
            };

            builder.AddField(x =>
            {
                x.Name = "Nickname: ";
                x.Value = nickname;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Created: ";
                x.Value = created;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Joined: ";
                x.Value = joined;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Status: ";
                x.Value = status;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Discriminator: ";
                x.Value = "#" + discriminator;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "ID: ";
                x.Value = id;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Playing: ";
                x.Value = playing;
                x.IsInline = false;
            });

            builder.AddField(x =>
            {
                x.Name = "Avatar: ";
                x.Value = "[[Link]](" + avatarURL + ")";
                x.IsInline = false;
            });

            builder.ImageUrl = avatarURL;
            return builder;
        }
    }
}
