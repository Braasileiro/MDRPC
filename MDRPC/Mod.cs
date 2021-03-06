using MelonLoader;
using MDRPC.Patches;

namespace MDRPC
{
    public class Mod : MelonMod
    {
        public override void OnApplicationStart()
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
