using Il2CppAssets.Scripts.Database;

namespace MDRPC.Models;

internal class CharacterModel
{
    private static readonly List<string> CosCharacters = new()
    {
        { "Rin" },
        { "Buro" },
        { "Marija" }
    };

    public static string GetName()
    {
        var entity = GlobalDataBase
            .dbConfig
            .m_ConfigDic["character"]
            .Cast<DBConfigCharacter>()
            .GetLocal()
            .GetInfoByIndex(DataHelper.selectedRoleIndex);

        if (entity != null)
        {
			if (CosCharacters.Contains(entity.characterName, StringComparer.OrdinalIgnoreCase))
				return $"{entity.cosName} {entity.characterName}";

			return entity.characterName;
		}

        return Constants.Discord.UnknownCharacter;
	}
}
