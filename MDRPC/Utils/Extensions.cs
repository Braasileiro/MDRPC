using System;
using Assets.Scripts.PeroTools.Nice.Interface;

namespace MDRPC
{
    internal static class Extensions
    {
        public static string[] Split(this string str, string pattern)
        {
            return str.Split(new[] { pattern }, StringSplitOptions.None);
        }

        public static T Get<T>(this IVariable variable)
        {
            return VariableUtils.GetResult<T>(variable);
        }
    }
}
