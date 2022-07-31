using System.Collections.Generic;
using PeroPeroGames.GlobalDefines;

namespace MDRPC.Models
{
    internal class ElfinModel
    {
        private static readonly Dictionary<int, string> Types = new Dictionary<int, string>()
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
            { ElfinDefine.doctor, "Dr. Paige" }
        };

        public static string GetName(int id)
        {
            return Types.TryGetValue(id, out string value) ? value : id.ToString();
        }
    }
}
