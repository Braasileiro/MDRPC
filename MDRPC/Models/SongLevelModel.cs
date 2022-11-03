using PeroPeroGames.GlobalDefines;
using System.Collections.Generic;

namespace MDRPC.Models
{
    internal class SongLevelModel
    {
        private static readonly Dictionary<int, string> Types = new Dictionary<int, string>()
        {
            { DifficultyDefine.easy, "Easy" },
            { DifficultyDefine.normal, "Hard" },
            { DifficultyDefine.master, "Master" },
            { DifficultyDefine.hide, "Hidden" },
            { DifficultyDefine.spell, "Touhou" }
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
            return $"{Constants.Discord.SmallImagePlayingText} • {(Types.TryGetValue(difficulty, out string value) ? $"{value} {level}⭐" : "???")}";
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
                return $"{Constants.Discord.SmallImagePlaying}_hidden";
            else if (difficulty == DifficultyDefine.spell)
                return $"{Constants.Discord.SmallImagePlaying}_touhou";
            else
                return Constants.Discord.SmallImagePlaying;
        }
    }
}