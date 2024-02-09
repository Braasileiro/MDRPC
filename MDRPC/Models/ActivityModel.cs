using Il2CppAssets.Scripts.Database;

namespace MDRPC.Models;

internal class ActivityModel
{
    public readonly bool isPlaying;
    private readonly string playerCharacter;
    private readonly string playerElfin;
    private readonly double playerLevel;

    private readonly string playerName;
    private readonly string[] songInfo;
    private readonly SongLevelModel songLevel;

    private readonly MusicInfo musicInfo;

    public ActivityModel(bool isPlaying, string levelInfo)
    {
        // Menu Check
        this.isPlaying = isPlaying;

        // MusicInfo
        musicInfo = BattleHelper.MusicInfo();

        // Song
        songInfo = !string.IsNullOrEmpty(levelInfo) ? levelInfo.Split(" - ") : null;

        playerName = DataHelper.nickname;
        playerLevel = DataHelper.Level;

		if (isPlaying)
        {
            songLevel = new SongLevelModel(musicInfo);
            playerElfin = ElfinModel.GetName();
            playerCharacter = CharacterModel.GetName();
        }
    }

    public string GetDetails()
    {
        if (!isPlaying)
            return Constants.Discord.MenuTitle;
        return songInfo.ElementAtOrDefault(0) ?? Constants.Discord.UnknownSong;
    }

    public string GetState()
    {
        if (!isPlaying)
            return Constants.Discord.MenuBrowsing;
        return songInfo.ElementAtOrDefault(1) ?? Constants.Discord.UnknownAuthor;
    }

    public string GetLargeImage()
    {
        if (!isPlaying)
            return Constants.Discord.DefaultImage;
        return $"https://raw.githubusercontent.com/simon300000/musedash.moe/master/covers-raw/{musicInfo.cover}.png";
	}

    public string GetLargeImageText()
    {
        if (!isPlaying)
            return $"{Global.MelonInfo.Name} {Global.MelonInfo.Version} • {playerName} (Lv. {playerLevel})";

        if (playerElfin != null)
            return $"{playerName} (Lv. {playerLevel}) • {playerCharacter} feat. {playerElfin}";

        return $"{playerName} (Lv. {playerLevel}) • {playerCharacter}";
	}

    public string GetSmallImage()
    {
        if (!isPlaying)
            return string.Empty;
        return songLevel.GetDifficultyImage();
    }

    public string GetSmallImageText()
    {
        if (!isPlaying)
            return string.Empty;
        return songLevel.GetDifficultyName();
    }
}
