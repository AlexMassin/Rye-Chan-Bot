using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using RyeChan_MacOS;

namespace RyeChanMacOS.UtilityCommands
{
    public class Translate : ModuleBase<SocketCommandContext>
    {
        #region Translate
        [Command("translate")]
        public async Task translate([Remainder] string s)
        {
            #region Langs
            String[,] lang = new String[104, 2];
            lang[0, 0] = "af"; lang[0, 1] = "Afrikaans";
            lang[1, 0] = "sq"; lang[1, 1] = "Albanian";
            lang[2, 0] = "am"; lang[2, 1] = "Amharic";
            lang[3, 0] = "ar"; lang[3, 1] = "Arabic";
            lang[4, 0] = "hy"; lang[4, 1] = "Armenian";
            lang[5, 0] = "az"; lang[5, 1] = "Azeerbaijani";
            lang[6, 0] = "eu"; lang[6, 1] = "Basque";
            lang[7, 0] = "be"; lang[7, 1] = "Belarusian";
            lang[8, 0] = "bn"; lang[8, 1] = "Bengali";
            lang[9, 0] = "bs"; lang[9, 1] = "Bosnian";
            lang[10, 0] = "bg"; lang[10, 1] = "Bulgarian";
            lang[11, 0] = "ca"; lang[11, 1] = "Catalan";
            lang[12, 0] = "ceb"; lang[12, 1] = "Cebuano";
            lang[13, 0] = "zh-CN"; lang[13, 1] = "Chinese (Simplified)";
            lang[14, 0] = "zh-TW"; lang[14, 1] = "Chinese (Traditional)";
            lang[15, 0] = "co"; lang[15, 1] = "Corsican";
            lang[16, 0] = "hr"; lang[16, 1] = "Croation";
            lang[17, 0] = "cs"; lang[17, 1] = "Czech";
            lang[18, 0] = "da"; lang[18, 1] = "Danish";
            lang[19, 0] = "nl"; lang[19, 1] = "Dutch";
            lang[20, 0] = "en"; lang[20, 1] = "English";
            lang[21, 0] = "eo"; lang[21, 1] = "Esperanto";
            lang[22, 0] = "et"; lang[22, 1] = "Estonian";
            lang[23, 0] = "fi"; lang[23, 1] = "Finnish";
            lang[24, 0] = "fr"; lang[24, 1] = "French";
            lang[25, 0] = "fy"; lang[25, 1] = "Frisian";
            lang[26, 0] = "gl"; lang[26, 1] = "Galician";
            lang[27, 0] = "ka"; lang[27, 1] = "Georgian";
            lang[28, 0] = "de"; lang[28, 1] = "German";
            lang[29, 0] = "el"; lang[29, 1] = "Greek";
            lang[30, 0] = "gu"; lang[30, 1] = "Gujarati";
            lang[31, 0] = "ht"; lang[31, 1] = "Haitian Creole";
            lang[32, 0] = "ha"; lang[32, 1] = "Hausa";
            lang[33, 0] = "haw"; lang[33, 1] = "Hawaiian";
            lang[34, 0] = "iw"; lang[34, 1] = "Hebrew";
            lang[35, 0] = "hi"; lang[35, 1] = "Hindi";
            lang[36, 0] = "hmn"; lang[36, 1] = "Hmong";
            lang[37, 0] = "hu"; lang[37, 1] = "Hungarian";
            lang[38, 0] = "is"; lang[38, 1] = "Icelandic";
            lang[39, 0] = "ig"; lang[39, 1] = "Igbo";
            lang[40, 0] = "id"; lang[40, 1] = "Indonesian";
            lang[41, 0] = "ga"; lang[41, 1] = "Irish";
            lang[42, 0] = "it"; lang[42, 1] = "Italian";
            lang[43, 0] = "ja"; lang[43, 1] = "Japanese";
            lang[44, 0] = "jw"; lang[44, 1] = "Javanese";
            lang[45, 0] = "kn"; lang[45, 1] = "Kannada";
            lang[46, 0] = "kk"; lang[46, 1] = "Kazakh";
            lang[47, 0] = "km"; lang[47, 1] = "Khmer";
            lang[48, 0] = "ko"; lang[48, 1] = "Korean";
            lang[49, 0] = "ku"; lang[49, 1] = "Kurdish";
            lang[50, 0] = "ky"; lang[50, 1] = "Kyrgyz";
            #endregion
            #region Return list of languages
            var cmdRequest = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(cmdRequest);
            if (s == "langs"){
                String list = "";
                for (int i = 0; i <= 50; i++){
                    list += lang[i, 1] + ": " + lang[i, 0] + "\n";
                }
                await Context.User.SendMessageAsync("Langauge: Encode\n\n" + list);
                var temp = await Context.Channel.SendMessageAsync(Context.User.Mention + ", the list has been sent to your DMs.");
                await Task.Delay(5000);
                await temp.DeleteAsync();
                return;
            }
            #endregion
            String message = "";
            String[] Params = s.Split(" ");
            if (Params.Length < 3) {
                await Context.Channel.SendMessageAsync("Missing parameters! `!translate src dst my text here`");
                return;
            }
            for (int i = 2; i < Params.Length; i++){
                message += Params[i] + " ";
            }
            message.Trim();
            String srcLang = Params[0];
            String dstLang = Params[1];
            String srcName = properLangName(lang, srcLang);
            String dstName = properLangName(lang, dstLang);
            if (srcName == "ERROR" || dstName == "ERROR")
            {
                await Context.Channel.SendMessageAsync("Invalid Language Code! Try `!translate langs` for the list of languages.");
                return;
            }

            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            client.Encoding = Encoding.UTF8;
            String old = message;
            message += "00x4675636B4F6666_FINAL_EOF_MEASURE";
            message = Regex.Replace(message, "[.]", " 0x92");
            message = Regex.Replace(message, "[!]", " 0x93");
            message = Regex.Replace(message, "[?]", " 0x94");
            //await Context.Channel.SendMessageAsync("m="+message); //debug
            string downloadString = @client.DownloadString("https://translate.googleapis.com/translate_a/single?client=gtx&sl="+srcLang+"&tl="+dstLang+"&dt=t&q=" + HttpUtility.UrlEncode(message));
            String result = HelperFunctions.glexStringLib.substringBetween(downloadString, "[[[\"", "00x4675636B4F6666_FINAL_EOF_MEASURE");
            result = Regex.Replace(result, "0x92", ".");
            result = Regex.Replace(result, "0x93", "!");
            result = Regex.Replace(result, "0x94", "?");
            await Context.Channel.SendMessageAsync(result);
        }
        #endregion

        private String properLangName(String[,] arr, String code){
            for (int i = 0; i < arr.GetLength(0); i++){
                if (arr[i, 0] == code) return arr[i, 1];
            }
            return "ERROR";
        }
    }
}