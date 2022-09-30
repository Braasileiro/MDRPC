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
            { DifficultyDefine.master, "Master" }
        };

        public static string GetDescription(int difficulty, string level)
        {
            return Types.TryGetValue(difficulty, out string value) ? $"Playing on {value} {level}⭐" : "???";
        }
    }
}
