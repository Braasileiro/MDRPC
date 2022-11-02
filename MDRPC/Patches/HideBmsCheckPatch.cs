using Assets.Scripts.Database;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;
using HarmonyLib;

namespace MDRPC.Patches
{
    [HarmonyPatch(typeof(SpecialSongManager), "HideBmsCheck")]
    internal class HideBmsCheckPatch
    {
        internal static string Level;
        internal static int Difficulty;

        private static void Postfix(MusicInfo selectedMusic, ref int selectedDifficulty, string __result)
        {
            Level = VariableUtils.GetResult<string>(Singleton<DataManager>.instance["Account"]["SelectedMusicLevel"]);
            Difficulty = VariableUtils.GetResult<int>(Singleton<DataManager>.instance["Account"]["SelectedDifficulty"]);
            if (__result != null)
            {
                if (__result.EndsWith("_map4"))
                {
                    Level = selectedMusic.difficulty4;
                    Difficulty = 4;
                }
                if (__result.EndsWith("_map5"))
                {
                    Level = selectedMusic.difficulty5;
                    Difficulty = 5;
                }
            }
        }
    }
}