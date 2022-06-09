using MelonLoader;
using MDRPC.Patches;

namespace MDRPC
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("Loaded!");

            // Global
            Global.MelonInfo = Info;
            Global.MelonLogger = LoggerInstance;
            Global.MelonHarmony = HarmonyInstance;

            // Patches
            DiscordPatch.DoIt();
        }

        public override void OnApplicationQuit()
        {
            // Dispose Patches
            DiscordPatch.Dispose();
        }
    }
}
