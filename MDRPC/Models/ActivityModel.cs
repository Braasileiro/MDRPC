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
            // Account
            var playerAccount = Singleton<DataManager>.instance["Account"];

            // Song
            this.isPlaying = isPlaying;

            songInfo = levelInfo.Split(new[] { " - " }, StringSplitOptions.None);

            songLevel = new SongLevelModel(
                level: VariableUtils.GetResult<string>(playerAccount["SelectedMusicLevel"]),
                difficulty: VariableUtils.GetResult<int>(playerAccount["SelectedDifficulty"])
            );

            elfin = ElfinModel.GetName(VariableUtils.GetResult<int>(playerAccount["SelectedElfinIndex"]));

            character = CharacterModel.GetName(VariableUtils.GetResult<int>(playerAccount["SelectedRoleIndex"]));
        }

        public string GetDetails()
        {
            if (!isPlaying)
            {
                return Constants.Discord.MenuTitle;
            }

            return songInfo.ElementAtOrDefault(0) ?? Constants.Discord.UnknownSong;
        }

        public string GetState()
        {
            if (!isPlaying)
            {
                return Constants.Discord.MenuBrowsing;
            }

            return songInfo.ElementAtOrDefault(1) ?? Constants.Discord.UnknownAuthor;
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

            return $"{character} feat. {elfin}";
        }

        public string GetSmallImage()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }

            return songLevel.GetDifficultyImage();
        }

        public string GetSmallImageText()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }

            return songLevel.GetDifficultyName();
        }
    }
}
