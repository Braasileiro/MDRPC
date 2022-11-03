using MDRPC.Patches;
using MelonLoader;

namespace MDRPC
{
    public class Mod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Loaded.");

            // Global
            Global.MelonInfo = Info;
            Global.MelonLogger = LoggerInstance;
            Global.MelonHarmony = HarmonyInstance;

            // Patches
            DiscordPatch.Init();
        }

        public override void OnApplicationQuit()
        {
            // Dispose things here
            DiscordPatch.Dispose();
        }
    }
}