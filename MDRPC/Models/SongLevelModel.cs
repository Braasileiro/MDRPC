using Il2CppAssets.Scripts.Database;
using Il2CppPeroPeroGames.GlobalDefines;

namespace MDRPC.Models;

internal class SongLevelModel
{
	private static readonly Dictionary<int, string> DifficultyNames = new()
	{
		{ DifficultyDefine.easy, "Easy" },
		{ DifficultyDefine.normal, "Hard" },
		{ DifficultyDefine.master, "Master" },
		{ DifficultyDefine.hide, "Hidden" },
		{ DifficultyDefine.spell, "Touhou" }
	};

	private readonly string level;
	private readonly string difficulty;

	public SongLevelModel(MusicInfo musicInfo)
    {
		level = DataHelper.selectedDifficulty switch
		{
			1 => musicInfo.difficulty1,
			2 => musicInfo.difficulty2,
			3 => musicInfo.difficulty3,
			4 => musicInfo.difficulty4,
			5 => musicInfo.difficulty5,
			_ => "???"
		};

		difficulty = DifficultyNames.TryGetValue(DataHelper.selectedDifficulty, out var value) ? value : null;
	}

    public string GetDifficultyName()
    {
		if (difficulty != null)
			return $"{Constants.Discord.SmallImagePlayingText} • {difficulty} {level}⭐";

		return Constants.Discord.SmallImagePlayingText;
	}

    public string GetDifficultyImage()
    {
		if (difficulty != null)
			return $"{Constants.Discord.SmallImagePlaying}_{difficulty.ToLowerInvariant()}";

		return Constants.Discord.SmallImagePlaying;
    }
}
