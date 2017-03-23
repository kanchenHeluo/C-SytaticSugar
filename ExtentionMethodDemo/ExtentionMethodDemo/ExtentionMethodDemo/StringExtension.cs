

using System;
using System.Text.RegularExpressions;

namespace ExtentionMethodDemo
{
    public static class StringExtension
    {

        public static string TrimAll(this string str)
        {
            Regex r = new Regex(@"\s");
            return r.Replace(str.Trim(), String.Empty);
        }
    }
}
