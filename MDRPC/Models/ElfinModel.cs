using Il2CppPeroPeroGames.GlobalDefines;

namespace MDRPC.Models;

internal class ElfinModel
{
    private static readonly Dictionary<int, string> Types = new()
    {
        { ElfinDefine.none, "None" },
        { ElfinDefine.cat, "Mio Sir" },
        { ElfinDefine.angel, "Angela" },
        { ElfinDefine.death_god, "Thanatos" },
        { ElfinDefine.carrot_robot, "Rabot-233" },
        { ElfinDefine.fan_robot, "Little Nurse" },
        { ElfinDefine.magic_girl, "Little Witch" },
        { ElfinDefine.dragon_girl, "Dragon Girl" },
        { ElfinDefine.devil, "Lilith" },
        { ElfinDefine.doctor, "Dr. Paige" },
        { ElfinDefine.silencer, "Silencer" },
        { ElfinDefine.neon_egg, "Neon Egg" }
    };

    public static string GetName(int id)
    {
        return Types.TryGetValue(id, out var value) ? value : id.ToString();
    }
}