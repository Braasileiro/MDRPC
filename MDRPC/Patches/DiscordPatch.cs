using System;
using Discord;
using HarmonyLib;
using MDRPC.Models;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;

namespace MDRPC.Patches
{
    class DiscordPatch
    {
        private static Activity _activity;
        private static DiscordManager _manager;
        private static bool _reinstantiated = false;

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
            // Reinstantiate SDK
            Reinstantiate(__instance);

            if (_reinstantiated)
            {
                // Account Data
                SingletonDataObject account = Singleton<DataManager>.instance["Account"];

                // PlayerName
                string player = VariableUtils.GetResult<string>(account["PlayerName"]);

                if (!isPlaying)
                {
                    _activity = new Activity
                    {
                        Details = "Menu",
                        State = "Browsing",
                        Assets = new ActivityAssets()
                        {
                            LargeImage = "default",
                            LargeText = $"{player} • {Global.MelonInfo.Name} {Global.MelonInfo.Version} by {Global.MelonInfo.Author}"
                        }
                    };
                }
                else
                {
                    int elfin = VariableUtils.GetResult<int>(account["SelectedElfinIndex"]);
                    int character = VariableUtils.GetResult<int>(account["SelectedRoleIndex"]);
                    int difficulty = VariableUtils.GetResult<int>(account["SelectedDifficulty"]);
                    string level = VariableUtils.GetResult<string>(account["SelectedMusicLevel"]);

                    _activity = new Activity
                    {
                        Details = levelInfo,
                        State = LevelModel.GetDescription(difficulty, level),
                        Assets = new ActivityAssets()
                        {
                            LargeImage = "default",
                            LargeText = $"{player} • {CharacterModel.GetName(character)} • {ElfinModel.GetName(elfin)}",
                            SmallImage = "playing",
                            SmallText = "Playing"
                        },
                        Timestamps = new ActivityTimestamps()
                        {
                            Start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                        }
                    };
                }
            }
        }

        private static void GetUpdatedActivity(ref Activity activity, ActivityManager.UpdateActivityHandler callback)
        {
            // Override Activity
            activity = _activity;
        }

        private static void Reinstantiate(DiscordManager manager)
        {
            if (Constants.DISCORD_CLIENT_ID <= 0) {
                #pragma warning disable CS0162
                Global.MelonLogger.Error("Please set an valid Discord ClientID.");
                #pragma warning restore CS0162
                return;
            }

            if (!_reinstantiated)
            {
                // Set Instance
                _manager = manager;

                // Dispose
                DiscordPatch.Dispose();

                // Init Discord SDK
                _manager.m_Discord = new Discord.Discord(Constants.DISCORD_CLIENT_ID, 1UL);

                if (_manager.m_Discord.isInit == Result.Ok)
                {
                    _reinstantiated = true;
                    _manager.m_ActivityManager = _manager.m_Discord.GetActivityManager();
                    _manager.m_ApplicationManager = _manager.m_Discord.GetApplicationManager();

                    Global.MelonLogger.Msg("Discord SDK reinstantiated.");
                }
                else
                {
                    Global.MelonLogger.Error("Failed to reinstantiate Discord SDK.");
                }
            }
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
