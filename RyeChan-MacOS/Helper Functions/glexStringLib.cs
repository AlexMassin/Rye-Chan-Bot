using System;
using System.Collections.Generic;

namespace RyeChanMacOS.HelperFunctions
{
    public class glexStringLib
    {
        public static string substringBetween(string str, string start, string end)
        {             return str.Split(start)[1].Split(end)[0].Trim();         }

        public static IEnumerable<String> handleMax(String s)
        {
            for (var i = 0; i < s.Length; i += 2000)
                yield return s.Substring(i, Math.Min(2000, s.Length - i));
        }
    }
}
