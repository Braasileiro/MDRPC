using Il2CppPeroPeroGames.GlobalDefines;

namespace MDRPC.Models;

internal class SongLevelModel
{
    private static readonly Dictionary<int, string> Types = new()
    {
        { DifficultyDefine.easy, "Easy" },
        { DifficultyDefine.normal, "Hard" },
        { DifficultyDefine.master, "Master" },
        { DifficultyDefine.hide, "Hidden" },
        { DifficultyDefine.spell, "Touhou" }
    };

    private readonly int difficulty;

    private readonly string level;

    public SongLevelModel(string level, int difficulty)
    {
        this.level = level;
        this.difficulty = difficulty;
    }

    public string GetDifficultyName()
    {
        return
            $"{Constants.Discord.SmallImagePlayingText} • {(Types.TryGetValue(difficulty, out var value) ? $"{value} {level}⭐" : "???")}";
    }

    public string GetDifficultyImage()
    {
        if (difficulty == DifficultyDefine.easy)
            return $"{Constants.Discord.SmallImagePlaying}_easy";
        if (difficulty == DifficultyDefine.normal)
            return $"{Constants.Discord.SmallImagePlaying}_hard";
        if (difficulty == DifficultyDefine.master)
            return $"{Constants.Discord.SmallImagePlaying}_master";
        if (difficulty == DifficultyDefine.hide)
            return $"{Constants.Discord.SmallImagePlaying}_hidden";
        if (difficulty == DifficultyDefine.spell)
            return $"{Constants.Discord.SmallImagePlaying}_touhou";
        return Constants.Discord.SmallImagePlaying;
    }
}