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
    public class PepeFeels : ModuleBase<SocketCommandContext>
    {
        #region Random pepe-feels image getter
        [Command("feels")]
        public async Task pepeFeels()
        {
            SocketUser s = Context.User;
            var u = s as SocketGuildUser;

            string[] img = new string[28];
            string[] name = new string[28];

            Random rnd = new Random();
            int pick = rnd.Next(0, img.Length);

            #region populate repositry
            img[0] = "https://i.imgur.com/zfgIbul.png";
            name[0] = "feels bad man";

            img[1] = "https://i.imgur.com/D6rAsCV.png";
            name[1] = "feels good man";

            img[2] = "https://i.imgur.com/n59PM8O.png";
            name[2] = "feels smug man";

            img[3] = "https://i.imgur.com/yJOfpfZ.png?1";
            name[3] = "feels very sad man";

            img[4] = "https://i.imgur.com/GQ8XsSp.png";
            name[4] = "feels trap man";

            img[5] = "https://i.imgur.com/3MzIsGg.png";
            name[5] = "feels angry man";

            img[6] = "https://i.imgur.com/gsgISog.png";
            name[6] = "feels trippy man";

            img[7] = "https://i.imgur.com/sAWXi0h.png";
            name[7] = "feels ugly man";

            img[8] = "https://i.imgur.com/5Hf807l.png";
            name[8] = "feels feed man";

            img[9] = "https://i.imgur.com/Gtryhb1.png";
            name[9] = "feels bitter man";

            img[10] = "https://i.imgur.com/Qxwzm7m.png";
            name[10] = "feels handsome man";

            img[11] = "https://i.imgur.com/8t0igvA.png";
            name[11] = "feels fast man";

            img[12] = "https://i.imgur.com/RIS7iaY.png";
            name[12] = "feels :regional_indicator_d::regional_indicator_e::regional_indicator_a::regional_indicator_d::regional_indicator_a::regional_indicator_s::regional_indicator_s: :b:";

            img[13] = "https://i.imgur.com/JjMkWSg.png";
            name[13] = "feels jacked man";

            img[14] = "https://i.imgur.com/KukMmwj.png";
            name[14] = "feels crying man";

            img[15] = "https://i.imgur.com/4XmMBcT.png";
            name[15] = "feels suicidal man";

            img[16] = "https://i.imgur.com/2Ea5fbL.png?1";
            name[16] = "fols bod mon";

            img[17] = "https://i.imgur.com/B18EU3B.png";
            name[17] = "feels special man";

            img[18] = "https://i.imgur.com/iJg2zT0.png";
            name[18] = "feels triggered man";

            img[19] = "https://i.imgur.com/BjOfa94.png";
            name[19] = "feels lonely man";

            img[20] = "https://i.imgur.com/LJzEAUi.png";
            name[20] = "feels emotional man";

            img[21] = "https://i.imgur.com/M0MEcQg.png";
            name[21] = "feels god-like man";

            img[22] = "https://i.imgur.com/bivxaHo.png";
            name[22] = "feels prideful man";

            img[23] = "https://i.imgur.com/1AkQlay.png";
            name[23] = "feels cool man";

            img[24] = "https://i.imgur.com/jTaPh6i.png";
            name[24] = "feels good m'lady";

            img[25] = "https://i.imgur.com/hVSaZiC.png";
            name[25] = "feels ok man";

            img[26] = "https://i.imgur.com/EW52xtO.png";
            name[26] = "feels upset man";

            img[26] = "https://i.imgur.com/JygYBBx.png";
            name[26] = "feels lewd man";

            img[27] = "https://i.imgur.com/3yCtMyF.jpg?1";
            name[27] = "feels uneasy man";

            #endregion

            var builder = new EmbedBuilder()
            {
                Color = new Color(0, 180, 0),
                Description = u.Mention + " " + name[pick] //soft hyphen to induce a newline
            };

            builder.ImageUrl = img[pick];

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
        #endregion
    }
}
