using System.Collections.Generic;
using PeroPeroGames.GlobalDefines;

namespace MDRPC.Models
{
    internal class CharacterModel
    {
        private static readonly Dictionary<int, string> Types = new Dictionary<int, string>()
        {
            { CharacterDefine.rin_rock, "Bassist Rin" },
            { CharacterDefine.rin_rampage, "Bad Girl Rin" },
            { CharacterDefine.rin_sleepy, "Sleepwalker Girl Rin" },
            { CharacterDefine.rin_bunny, "Bunny Girl Rin" },
            { CharacterDefine.rin_santa, "Christmas Gift Rin" },
            { CharacterDefine.rin_worker, "Part-Time Warrior Rin" },
            { CharacterDefine.buro_pilot, "Pilot Buro" },
            { CharacterDefine.buro_robot, "Idol Buro" },
            { CharacterDefine.buro_zombie, "Zombie Girl Buro" },
            { CharacterDefine.buro_joker, "Joker Buro" },
            { CharacterDefine.buro_jk, "Sailor Suit Buro" },
            { CharacterDefine.marija_violin, "Violinist Marija" },
            { CharacterDefine.marija_maid, "Maid Marija" },
            { CharacterDefine.marija_magic, "Magical Girl Marija" },
            { CharacterDefine.marija_evil, "Little Devil Marija" },
            { CharacterDefine.marija_black, "The Girl In Black Marija" },
            { CharacterDefine.marija_sister, "Sister Marija" },
            { CharacterDefine.yume, "Navigator Yume" },
            { CharacterDefine.neko, "NEKO#ΦωΦ" },
            { CharacterDefine.reimu, "Hakurei Reimu" },
            { CharacterDefine.clear, "El_Clear" },
            { CharacterDefine.marisa, "Kirisame Marisa" },
            { CharacterDefine.ark_nights_amiya, "Amiya" }
        };

        public static string GetName(int id)
        {
            return Types.TryGetValue(id, out string value) ? value : id.ToString();
        }
    }
}