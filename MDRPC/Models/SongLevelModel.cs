using System.Collections.Generic;
using PeroPeroGames.GlobalDefines;

namespace MDRPC.Models
{
    internal class SongLevelModel
    {
        private static readonly Dictionary<int, string> Types = new Dictionary<int, string>()
        {
            { DifficultyDefine.easy, "Easy" },
            { DifficultyDefine.normal, "Hard" },
            { DifficultyDefine.master, "Master" },
            { DifficultyDefine.hide, "Master (Hide)" }
        };


        private readonly string level;
        private readonly int difficulty;
        
        
        public SongLevelModel(string level, int difficulty)
        {
            this.level = level;
            this.difficulty = difficulty;
        }

        public string GetDifficultyName()
        {
            return Types.TryGetValue(difficulty, out string value) ? $"{value} {level}⭐" : "???";
        }

        public string GetDifficultyImage()
        {
            if (difficulty == DifficultyDefine.easy)
                return $"{Constants.Discord.SmallImagePlaying}_easy";

            else if (difficulty == DifficultyDefine.normal)
                return $"{Constants.Discord.SmallImagePlaying}_hard";

            else if (difficulty == DifficultyDefine.master)
                return $"{Constants.Discord.SmallImagePlaying}_master";

            else if (difficulty == DifficultyDefine.hide)
                return $"{Constants.Discord.SmallImagePlaying}_hide";

            else
                return Constants.Discord.SmallImagePlaying;
        }
    }
}
