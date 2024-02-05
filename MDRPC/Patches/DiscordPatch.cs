using System.Drawing;
using HarmonyLib;
using MelonLoader;
using MDRPC.Models;
using Il2CppDiscord;
using Il2Cpp;
using Il2CppInterop.Runtime;

namespace MDRPC.Patches
{
    internal class DiscordPatch
    {
        // RPC
        private static Activity activity;

        private static DiscordManager manager;
        private static readonly long timePlayed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // Song
        private static ActivityModel activityModel;

        // States
        private static bool reinstantiated = false;

        
        public static void Init()
        {
            // Assembly-CSharp::DiscordManager.SetUpdateActivity
            Global.MelonHarmony.Patch(
                original: AccessTools.Method(
                    type: typeof(DiscordManager),
                    name: "SetUpdateActivity",
                    parameters: new Type[] {
                        typeof(bool),
                        typeof(string)
                    }
                ),
                prefix: AccessTools.Method(typeof(DiscordPatch), "SetUpdateActivity").ToNewHarmonyMethod()
            );

            // Assembly-CSharp::Discord.ActivityManager.UpdateActivity
            Global.MelonHarmony.Patch(
                original: AccessTools.Method(
                    type: typeof(ActivityManager),
                    name: "UpdateActivity",
                    parameters: new Type[] {
                        typeof(Activity),
                        typeof(ActivityManager.UpdateActivityHandler)
                    }
                ),
                prefix: AccessTools.Method(typeof(DiscordPatch), "GetUpdatedActivity").ToNewHarmonyMethod()
            );
        }

        private static void SetUpdateActivity(ref DiscordManager __instance, bool isPlaying, string levelInfo)
        {
            try
            {
                // Reinstantiate Check
                Reinstantiate(__instance);

                if (reinstantiated)
                {
                    // Build ActivityModel
                    activityModel = new ActivityModel(
                        isPlaying: isPlaying,
                        levelInfo: levelInfo
                    );

                    // Update Activity
                    UpdateActivity();
                }
            }
            catch (Exception e)
            {
                Global.MelonLogger.Error($"Failed to update the Discord Activity: {e.Message}");
            }
        }

        private static void GetUpdatedActivity(ref Activity activity, ActivityManager.UpdateActivityHandler callback)
        {
            // Override Activity
            activity = DiscordPatch.activity;
        }

        private static void Reinstantiate(DiscordManager manager)
        {
            if (!reinstantiated)
            {
                // Current Manager
                DiscordPatch.manager = manager;

                // Dispose Current Instance
                Dispose();

                // Reinit Discord Client
                DiscordPatch.manager.m_Discord = new Discord(Constants.Discord.ClientId, 1UL);

                if (DiscordPatch.manager.m_Discord.isInit == Result.Ok)
                {
                    DiscordPatch.manager.m_ActivityManager = DiscordPatch.manager.m_Discord.GetActivityManager();
                    DiscordPatch.manager.m_ApplicationManager = DiscordPatch.manager.m_Discord.GetApplicationManager();
                    reinstantiated = true;

                    Global.MelonLogger.Msg("Discord Client reinstantiated.");
                }
                else
                {
                    Global.MelonLogger.Error("Failed to reinstantiate Discord Client.");
                }
            }
        }

        private static void UpdateActivity()
        {
            // Requires a workaround to create ValueType objects
            activity = Extensions.CreateValueType<Activity>();
            activity.Details = activityModel.GetDetails();
            activity.State = activityModel.GetState();
            activity.Assets = Extensions.CreateValueType<ActivityAssets>();
            activity.Assets.LargeImage = activityModel.GetLargeImage();
            activity.Assets.LargeText = activityModel.GetLargeImageText();
            activity.Assets.SmallImage = activityModel.GetSmallImage();
            activity.Assets.SmallText = activityModel.GetSmallImageText();
            activity.Timestamps = new ActivityTimestamps
            {
                Start = timePlayed
            };
        }

        public static void Dispose()
        {
            manager.m_ActivityManager = null;
            manager.m_ApplicationManager = null;
            manager.m_Discord.Dispose();

            Global.MelonLogger.Msg("Discord Client instance disposed.");
        }
    }
}