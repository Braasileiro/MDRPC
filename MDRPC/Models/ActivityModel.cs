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

        private readonly string elfin;
        private readonly string character;


        public ActivityModel(bool isPlaying, string levelInfo)
        {
            // Menu Check
            this.isPlaying = isPlaying;

            if (isPlaying)
            {
                var account = Singleton<DataManager>.instance["Account"];

                songInfo = levelInfo.Split(new[] { " - " }, StringSplitOptions.None);

                songLevel = new SongLevelModel(
                    level: VariableUtils.GetResult<string>(account["SelectedMusicLevel"]),
                    difficulty: VariableUtils.GetResult<int>(account["SelectedDifficulty"])
                );

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
                return $"{Global.MelonInfo.Name} {Global.MelonInfo.Version}";
            }
            else
            {
                return $"{character} feat. {elfin}";
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
