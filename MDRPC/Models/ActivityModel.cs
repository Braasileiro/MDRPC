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

        private readonly string playerName;
        private readonly double playerLevel;
        private readonly string playerElfin;
        private readonly string playerCharacter;
        private readonly string playerSelectedSongLevel;


        public ActivityModel(bool isPlaying, string levelInfo)
        {
            // Song
            this.isPlaying = isPlaying;
            songInfo = levelInfo.Split(new[] { " - " }, StringSplitOptions.None);

            // Account
            var playerAccount = Singleton<DataManager>.instance["Account"];

            playerName = VariableUtils.GetResult<string>(playerAccount["PlayerName"]);

            playerLevel = Math.Ceiling(VariableUtils.GetResult<int>(playerAccount["Exp"]) / 100d);

            playerElfin = ElfinModel.GetName(VariableUtils.GetResult<int>(playerAccount["SelectedElfinIndex"]));

            playerCharacter = CharacterModel.GetName(VariableUtils.GetResult<int>(playerAccount["SelectedRoleIndex"]));

            playerSelectedSongLevel = SongLevelModel.GetDescription(
                difficulty: VariableUtils.GetResult<int>(playerAccount["SelectedDifficulty"]),
                level: VariableUtils.GetResult<string>(playerAccount["SelectedMusicLevel"])
            );
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
                return $"{Global.MelonInfo.Name} {Global.MelonInfo.Version} • {playerName} (Lv. {playerLevel})";
            }

            return $"{playerName} (Lv. {playerLevel}) • {playerCharacter} feat. {playerElfin}";
        }

        public string GetSmallImage()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }

            return Constants.Discord.SmallImagePlaying;
        }

        public string GetSmallImageText()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }

            return $"{Constants.Discord.SmallImagePlayingText} • {playerSelectedSongLevel}";
        }
    }
}
