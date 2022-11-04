using HarmonyLib;
using Assets.Scripts.Database;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;

namespace MDRPC.Patches
{
    [HarmonyPatch(typeof(SpecialSongManager), "HideBmsCheck")]
    internal class HideBmsCheckPatch
    {
        internal static string Level;
        internal static int Difficulty;

        private static void Postfix(MusicInfo selectedMusic, ref int selectedDifficulty, string __result)
        {
            var account = Singleton<DataManager>.instance["Account"];

            Level = account["SelectedMusicLevel"].Get<string>();
            Difficulty = account["SelectedDifficulty"].Get<int>();

            if (selectedDifficulty == 4)
            {
                Level = selectedMusic.difficulty4;
                Difficulty = 4;
            }
            else if (selectedDifficulty == 5)
            {
                Level = selectedMusic.difficulty5;
                Difficulty = 5;
            }
        }
    }
}