using Il2CppAssets.Scripts.Database;

namespace MDRPC.Models;

internal class ElfinModel
{
    public static string GetName(int id)
    {
        var entity = GlobalDataBase.dbConfig.m_ConfigDic["elfin"].Cast<DBConfigElfin>().GetLocal().GetInfoByIndex(id);

		if (entity != null)
			return entity.name;

		return id.ToString();
	}
}
