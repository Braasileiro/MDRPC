using System;
using Discord;
using HarmonyLib;
using MDRPC.Models;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;

namespace MDRPC.Patches
{
    class DiscordPatch
    {
        private static Activity _activity;
        private static DiscordManager _manager;
        private static bool _isReinstantiated = false;

        public static void DoIt()
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
                prefix: new HarmonyMethod(AccessTools.Method(typeof(DiscordPatch), "SetUpdateActivity"))
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
                prefix: new HarmonyMethod(AccessTools.Method(typeof(DiscordPatch), "GetUpdatedActivity"))
            );
        }

        private static void SetUpdateActivity(ref DiscordManager __instance, bool isPlaying, string levelInfo)
        {
            try
            {
                // Reinstantiate SDK
                Reinstantiate(__instance);

                if (_isReinstantiated)
                {
                    // Model
                    var model = new ActivityModel(
                        isPlaying: isPlaying,
                        levelInfo: levelInfo,
                        playerAccount: Singleton<DataManager>.instance["Account"]
                    );

                    // Activity
                    if (!isPlaying)
                    {
                        _activity = new Activity
                        {
                            Details = model.GetDetails(),
                            State = model.GetState(),
                            Assets = new ActivityAssets()
                            {
                                LargeImage = model.GetLargeImage(),
                                LargeText = model.GetLargeImageText()
                            }
                        };
                    }
                    else
                    {
                        _activity = new Activity
                        {
                            Details = model.GetDetails(),
                            State = model.GetState(),
                            Assets = new ActivityAssets()
                            {
                                LargeImage = model.GetLargeImage(),
                                LargeText = model.GetLargeImageText(),
                                SmallImage = model.GetSmallImage(),
                                SmallText = model.GetSmallImageText(),

                            },
                            Timestamps = new ActivityTimestamps()
                            {
                                Start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                            }
                        };
                    }
                }
            }
            catch (Exception e)
            {
                Global.MelonLogger.Error($"Failed to update the Discord Activity: {e.Message}");
            }
        }

        private static void Reinstantiate(DiscordManager manager)
        {
            #pragma warning disable CS0162
            if (Constants.DISCORD_CLIENT_ID <= 0)
            {
                Global.MelonLogger.Error("Please set an valid Discord ClientID.");
            }
            else if (!_isReinstantiated)
            {
                // Set Current Instance
                _manager = manager;

                // Dispose Current Instance
                Dispose();

                // Init Discord SDK
                _manager.m_Discord = new Discord.Discord(Constants.DISCORD_CLIENT_ID, 1UL);

                if (_manager.m_Discord.isInit == Result.Ok)
                {
                    _isReinstantiated = true;
                    _manager.m_ActivityManager = _manager.m_Discord.GetActivityManager();
                    _manager.m_ApplicationManager = _manager.m_Discord.GetApplicationManager();

                    Global.MelonLogger.Msg("Discord SDK reinstantiated.");
                }
                else
                {
                    Global.MelonLogger.Error("Failed to reinstantiate Discord SDK.");
                }
            }
            #pragma warning restore CS0162
        }

        private static void GetUpdatedActivity(ref Activity activity, ActivityManager.UpdateActivityHandler callback)
        {
            // Override
            activity = _activity;
        }

        public static void Dispose()
        {
            _manager.m_ActivityManager = null;
            _manager.m_ApplicationManager = null;
            _manager.m_Discord.Dispose();

            Global.MelonLogger.Msg("Discord SDK instance disposed.");
        }
    }
}
