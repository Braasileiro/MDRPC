using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Database;

namespace MDRPC.Patches
{
    [HarmonyPatch(typeof(SpecialSongManager), "HideBmsCheck")]
    internal class HideBmsCheckPatch
    {
        internal static string Level;
        internal static int Difficulty;

        private static void Postfix(MusicInfo selectedMusic, ref int selectedDifficulty, string __result)
        {
            switch (selectedDifficulty)
            {
                case 1:
                    Level = selectedMusic.difficulty1;
                    Difficulty = 1;
                    break;

                case 2:
                    Level = selectedMusic.difficulty2;
                    Difficulty = 2;
                    break;

                case 3:
                    Level = selectedMusic.difficulty3;
                    Difficulty = 3;
                    break;

                case 4:
                    Level = selectedMusic.difficulty4;
                    Difficulty = 4;
                    break;

                case 5:
                    Level = selectedMusic.difficulty5;
                    Difficulty = 5;
                    break;
            }
        }
    }
}