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
        private readonly string name;
        private readonly double level;
        private readonly string elfin;
        private readonly string character;


        public ActivityModel(bool isPlaying, string levelInfo)
        {
            // Menu Check
            this.isPlaying = isPlaying;

            if (isPlaying)
            {
                // Name and Author
                songInfo = levelInfo.Split(" - ");

                // Player Account JSON
                var account = Singleton<DataManager>.instance["Account"];

                songLevel = new SongLevelModel(
                    level: VariableUtils.GetResult<string>(account["SelectedMusicLevel"]),
                    difficulty: VariableUtils.GetResult<int>(account["SelectedDifficulty"])
                );

                name = VariableUtils.GetResult<string>(account["PlayerName"]);
                level = Math.Ceiling(VariableUtils.GetResult<int>(account["Exp"]) / 100d);
                elfin = ElfinModel.GetName(VariableUtils.GetResult<int>(account["SelectedElfinIndex"]));
                character = CharacterModel.GetName(VariableUtils.GetResult<int>(account["SelectedRoleIndex"]));
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
                return $"{Global.MelonInfo.Name} {Global.MelonInfo.Version} • {name} (Lv. {level}";
            }
            else
            {
                return $"{name} (Lv. {level}) • {character} feat. {elfin}";
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
