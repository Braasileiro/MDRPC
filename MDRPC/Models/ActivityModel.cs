using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Nice.Datas;
using Il2CppAssets.Scripts.PeroTools.Nice.Interface;
using MDRPC.Patches;

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

    public ActivityModel(bool isPlaying, string levelInfo)
    {
        // Menu Check
        this.isPlaying = isPlaying;

        // Song
        songInfo = !string.IsNullOrEmpty(levelInfo) ? levelInfo.Split(" - ") : null;

        // Account
        var account = Singleton<DataManager>.instance["Account"];

        playerName = account["PlayerName"].GetResult<string>();
        playerLevel = Math.Ceiling(account["Exp"].GetResult<int>() / 100d);

        if (isPlaying)
        {
            songLevel = new SongLevelModel(
                HideBmsCheckPatch.Level,
                HideBmsCheckPatch.Difficulty
            );

            playerElfin = ElfinModel.GetName(account["SelectedElfinIndex"].GetResult<int>());
            playerCharacter = CharacterModel.GetName(account["SelectedRoleIndex"].GetResult<int>());
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
        return Constants.Discord.DefaultImage;
    }

    public string GetLargeImageText()
    {
        if (!isPlaying)
            return $"{Global.MelonInfo.Name} {Global.MelonInfo.Version} • {playerName} (Lv. {playerLevel})";
        return $"{playerName} (Lv. {playerLevel}) • {playerCharacter} feat. {playerElfin}";
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