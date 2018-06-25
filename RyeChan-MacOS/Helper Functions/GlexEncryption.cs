using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RyeChanMacOS.HelperFunctions
{
    public class GlexEncryption
    {
        #region Neutral Helpers
        #region Nine's Complement
        public static String ninesComp(String s)
        {
            String result = "";
            foreach (Char c in s)
            {
                if (Char.IsDigit(c))
                {
                    result += (9 - Char.GetNumericValue(c)).ToString() + getRandBuffer();
                    continue;
                }
                result += c;
            }
            return result;
        }
        #endregion
        #region Reverse Odd Words
        public static String reverseOdds(String s)
        {
            String[] words = s.Split(" ");
            for (int i = 0; i < words.Length; i++)
            {
                if (Regex.Replace(words[i], "[^A-Za-z0-9]", "").Length % 2 != 0)
                { //excluding non alphanum
                    while (words[i][words[i].Length - 1] == '!' || words[i][words[i].Length - 1] == ',' || words[i][words[i].Length - 1] == '.' || words[i][words[i].Length - 1] == '?')
                    {
                        words[i] = words[i][words[i].Length - 1] + words[i].Substring(0, words[i].Length - 1);
                    }
                    words[i] = reverse(words[i]);
                }
            }
            return String.Join(" ", words);
        }
        #endregion
        #region Reverse
        private static String reverse(String s)
        {
            if (s.Length <= 1) return s;
            return reverse(s.Substring(1)) + s[0]; //I love recursion 
        }
        #endregion
        #region Reverse Entire Message's Words
        //this makes odd letter words in the correct order again
        public static String reverseAll(String s)
        {
            String[] words = s.Split(" ");
            return String.Join(" ", words.Reverse());
        }
        #endregion
        #region Random Buffer Char
        private static String buffers = "|";
        private static Random rnd = new Random();
        public static char getRandBuffer()
        {
            char c = buffers[rnd.Next(buffers.Length)];
            //Console.WriteLine("c=" + c);
            return c;
        }
        #endregion
        #region Check Key
        public static bool isInvalidKey(String s)
        {
            return (!Regex.IsMatch(s, "^[a-zA-Z]+"));
        }
        #endregion
        #endregion
        #region Encryption Helpers
        #region Replace Vowel -> Digital Root
        //Not including the digital root calculation
        //Map alphabet to numbers, a=1, b=2, c=3, etc...
        //a, e, i, o, u, y => 1, 5, 9, 15, 21, 25
        //7 * their appearance = 7, 35, 63, 105, 147, 175
        //digital root of each => [7], 3+5=[8], 6+3=[9], 1+0+5=[6], 1+4+7=1+2=[3], 1+7+5=1+3=[4]
        public static String digitalRoot(String s)
        {
            String result = "";
            foreach (Char c in s)
            {
                if (c == 'a')
                {
                    result += '7';
                    continue;
                }
                if (c == 'e')
                {
                    result += '8';
                    continue;
                }
                if (c == 'i')
                {
                    result += '9';
                    continue;
                }
                if (c == 'o')
                {
                    result += '6';
                    continue;
                }
                if (c == 'u')
                {
                    result += '3';
                    continue;
                }
                if (c == 'y')
                {
                    result += '4';
                    continue;
                }
                result += c;
            }
            return result;
        }
        #endregion
        #region Vigenere Encrypt
        public static String VigenereEncrpyt(String s, String key)
        {
            String result = "";
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                Char c = s[i].ToString().ToLower()[0];
                bool capital = false;
                if (s[i] != c.ToString().ToLower()[0]) capital = true;
                if (c == ' ' || !Char.IsLetter(c) || Char.IsDigit(c))
                {
                    result += c;
                    continue;
                }
                if (capital) result += ((Char)((c + key[j] - 2 * 'a') % 26 + 'a')).ToString().ToUpper();
                else result += (Char)((c + key[j] - 2 * 'a') % 26 + 'a');
                j = ++j % key.Length;
            }
            return result;
        }
        #endregion
        #endregion
        #region Decryption Helpers
        #region Vigenere Decrypt
        public static String VigenereDecrpyt(String s, String key)
        {
            String result = "";
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                Char c = s[i].ToString().ToLower()[0];
                bool capital = false;
                if (s[i] != c.ToString().ToLower()[0]) capital = true;
                if (c == ' ' || !Char.IsLetter(c) || Char.IsDigit(c))
                {
                    result += c;
                    continue;
                }
                if (capital) result += ((Char)((c - key[j] + 26) % 26 + 'a')).ToString().ToUpper();
                else result += (Char)((c - key[j] + 26) % 26 + 'a');
                j = ++j % key.Length;
            }
            return result;
        }
        #endregion
        #region Digital "Square" -> Revert Digital Root operations
        public static String digitalSquare(String s)
        {
            String result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (i == s.Length-1)
                {
                    if (s[i] == '7')
                    {
                        result += 'a';
                        continue;
                    }
                    if (s[i] == '8')
                    {
                        result += 'e';
                        continue;
                    }
                    if (s[i] == '9')
                    {
                        result += 'i';
                        continue;
                    }
                    if (s[i] == '6')
                    {
                        result += 'o';
                        continue;
                    }
                    if (s[i] == '3')
                    {
                        result += 'u';
                        continue;
                    }
                    if (s[i] == '4')
                    {
                        result += 'y';
                        continue;
                    }
                }
                //try
                //{
                    if (s[i] == '7' && !buffers.Contains(s[i + 1]))
                    {
                        result += 'a';
                        continue;
                    }
                    if (s[i] == '8' && !buffers.Contains(s[i + 1]))
                    {
                        result += 'e';
                        continue;
                    }
                    if (s[i] == '9' && !buffers.Contains(s[i + 1]))
                    {
                        result += 'i';
                        continue;
                    }
                    if (s[i] == '6' && !buffers.Contains(s[i + 1]))
                    {
                        result += 'o';
                        continue;
                    }
                    if (s[i] == '3' && !buffers.Contains(s[i + 1]))
                    {
                        result += 'u';
                        continue;
                    }
                    if (s[i] == '4' && !buffers.Contains(s[i + 1]))
                    {
                        result += 'y';
                        continue;
                    }
                    result += s[i];
                //} catch (Exception e){
                    //Console.WriteLine("Caught " + e);
                //}
            }
            return result;
        }
        #endregion
        #region Revert Nine's Comp
        public static String revertNinesComp(String s)
        {
            //String old = Regex.Replace(s, "[^a-zA-Z0-9?!,.' ]", "");
            String old = s;
            foreach (char c in buffers){
                old = old.Replace(""+c, "");
            }
            String result = "";
            foreach (Char c in old)
            {
                if (Char.IsDigit(c))
                {
                    result += (9 - Char.GetNumericValue(c)).ToString();
                    continue;
                }
                result += c;
            }
            return result;
        }
        #endregion
        #endregion
    }
}