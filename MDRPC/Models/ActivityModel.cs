using System;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;

namespace MDRPC.Models
{
    public class ActivityModel
    {
        // Basic Info
        public readonly bool isPlaying;
        private readonly string levelInfo;

        // Player
        private string playerName;
        private double playerLevel;
        private string playerElfin;
        private string playerCharacter;
        private string playerSelectedSongLevel;


        public ActivityModel(bool isPlaying, string levelInfo, SingletonDataObject playerAccount)
        {
            this.isPlaying = isPlaying;
            this.levelInfo = levelInfo;

            GetAccountData(playerAccount);
        }

        private void GetAccountData(SingletonDataObject playerAccount)
        {
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
            if (!isPlaying) return "Menu";

            return levelInfo;
        }

        public string GetState()
        {
            if (!isPlaying) return "Browsing";

            return playerSelectedSongLevel;
        }

        public string GetLargeImage()
        {
            return "default";
        }

        public string GetLargeImageText()
        {
            if (!isPlaying)
            {
                return $"{playerName} (Lv. {playerLevel}) • {Global.MelonInfo.Name} {Global.MelonInfo.Version} by {Global.MelonInfo.Author}";
            }

            return $"{playerName} (Lv. {playerLevel}) • {playerCharacter} feat. {playerElfin}";
        }

        public string GetSmallImage()
        {
            if (!isPlaying) return "";

            return "playing";
        }

        public string GetSmallImageText()
        {
            if (!isPlaying) return "";

            return "Playing";
        }
    }
}
