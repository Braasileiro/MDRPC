using System;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;

namespace MDRPC.Models
{
    internal class ActivityModel
    {
        public readonly bool isPlaying;
        private readonly string levelInfo;
        private readonly string playerName;
        private readonly double playerLevel;
        private readonly string playerElfin;
        private readonly string playerCharacter;
        private readonly string playerSelectedSongLevel;


        public ActivityModel(bool isPlaying, string levelInfo)
        {
            // Info
            this.isPlaying = isPlaying;
            this.levelInfo = levelInfo;

            // Account Data
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
                return Constants.Discord.DetailsMenu;
            }

            return levelInfo;
        }

        public string GetState()
        {
            if (!isPlaying)
            {
                return Constants.Discord.StateMenu;
            }

            return playerSelectedSongLevel;
        }

        public string GetLargeImage()
        {
            return Constants.Discord.LargeImage;
        }

        public string GetLargeImageText()
        {
            if (!isPlaying)
            {
                return $"{playerName} (Lv. {playerLevel}) • {Global.MelonInfo.Name} {Global.MelonInfo.Version}";
            }

            return $"{playerName} (Lv. {playerLevel}) • {playerCharacter} feat. {playerElfin}";
        }

        public string GetSmallImage()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }

            return Constants.Discord.SmallImage;
        }

        public string GetSmallImageText()
        {
            if (!isPlaying)
            {
                return string.Empty;
            }

            return Constants.Discord.SmallImageText;
        }
    }
}
