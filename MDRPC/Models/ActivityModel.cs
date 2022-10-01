using System;
using System.Linq;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;

namespace MDRPC.Models
{
    internal class ActivityModel
    {
        public readonly bool isPlaying;
        private readonly string[] songInfo;
        private readonly SongLevelModel songLevel;

        private readonly string playerName;
        private readonly double playerLevel;
        private readonly string playerElfin;
        private readonly string playerCharacter;


        public ActivityModel(bool isPlaying, string levelInfo)
        {
            // Menu Check
            this.isPlaying = isPlaying;

            // Song
            songInfo = levelInfo.Split(" - ");

            // Account
            var account = Singleton<DataManager>.instance["Account"];

            playerName = VariableUtils.GetResult<string>(account["PlayerName"]);
            playerLevel = Math.Ceiling(VariableUtils.GetResult<int>(account["Exp"]) / 100d);

            if (isPlaying)
            {
                songLevel = new SongLevelModel(
                    level: VariableUtils.GetResult<string>(account["SelectedMusicLevel"]),
                    difficulty: VariableUtils.GetResult<int>(account["SelectedDifficulty"])
                );

                playerElfin = ElfinModel.GetName(VariableUtils.GetResult<int>(account["SelectedElfinIndex"]));
                playerCharacter = CharacterModel.GetName(VariableUtils.GetResult<int>(account["SelectedRoleIndex"]));
            }
        }

        public string GetDetails()
        {
            if (!isPlaying)
            {
                return Constants.Discord.MenuTitle;
            }
            else
            {
                return songInfo.ElementAtOrDefault(0) ?? Constants.Discord.UnknownSong;
            }
        }

        public string GetState()
        {
            if (!isPlaying)
            {
                return Constants.Discord.MenuBrowsing;
            }
            else
            {
                return songInfo.ElementAtOrDefault(1) ?? Constants.Discord.UnknownAuthor;
            }
        }

        public string GetLargeImage()
        {
            return Constants.Discord.DefaultImage;
        }

        public string GetLargeImageText()
        {
            if (!isPlaying)
            {
                return $"{Global.MelonInfo.Name} {Global.MelonInfo.Version} • {playerName} (Lv. {playerLevel}";
            }
            else
            {
                return $"{playerName} (Lv. {playerLevel}) • {playerCharacter} feat. {playerElfin}";
            }
        }

        public string GetSmallImage()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }
            else
            {
                return songLevel.GetDifficultyImage();
            }
        }

        public string GetSmallImageText()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }
            else
            {
                return songLevel.GetDifficultyName();
            }
        }
    }
}
