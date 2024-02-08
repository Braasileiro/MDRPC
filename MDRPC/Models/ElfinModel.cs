using Il2CppAssets.Scripts.Database;

namespace MDRPC.Models;

internal class ElfinModel
{
    public static string GetName()
    {
		return GlobalDataBase
			.dbConfig
			.m_ConfigDic["elfin"]
			.Cast<DBConfigElfin>()
			.GetLocal()
			.GetInfoByIndex(DataHelper.selectedElfinIndex)
			.name;
	}
}
