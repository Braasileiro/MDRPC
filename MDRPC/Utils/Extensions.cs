using System;

namespace MDRPC
{
    internal static class Extensions
    {
        public static string[] Split(this string str, string pattern)
        {
            return str.Split(new[] { pattern }, StringSplitOptions.None);
        }
    }
}
