using Il2CppAssets.Scripts.Database;

namespace MDRPC.Models;

internal class ElfinModel
{
    public static string GetName()
    {
		var entity = GlobalDataBase
			.dbConfig
			.m_ConfigDic["elfin"]
			.Cast<DBConfigElfin>()
			.GetLocal()
			.GetInfoByIndex(DataHelper.selectedElfinIndex);

		if (entity != null)
			return entity.name;

		return null;
	}
}
