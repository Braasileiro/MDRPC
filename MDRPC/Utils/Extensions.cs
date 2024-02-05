using Il2CppAssets.Scripts.PeroTools.Nice.Interface;
using Il2CppInterop.Runtime;

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

        /// <summary>
        /// Workaround to create ValueType objects with Il2CppInterop
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <returns>Properly initialized ValueType object</returns>
        public static T CreateValueType<T>()
        {
            return (T)Activator.CreateInstance(typeof(T),
                IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<T>.NativeClassPtr));
        }
    }
}