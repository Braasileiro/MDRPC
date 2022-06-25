namespace MDRPC.Models
{
    public class CharacterModel
    {
        public enum Type
        {
            BassistRin = 0,
            BadGirlRin = 1,
            SleepwalkerGirlRin = 2,
            BunnyGirlRin = 3,
            ChristmasGiftRin = 13,
            PartTimeWarriorRin = 17,
            PilotBuro = 4,
            IdolBuro = 5,
            ZombieGirlBuro = 6,
            JokerBuro = 7,
            SailorSuitBuro = 14,
            ViolinistMarija = 8,
            MaidMarija = 9,
            MagicalGirlMarija = 10,
            LittleDevilMarija = 11,
            TheGirlInBlackMarija = 12,
            SisterMarija = 20,
            NavigatorYume = 15,
            NEKOOwO = 16,
            HakureiReimu = 18,
            ElClear = 19
        }

        public static string GetName(int id)
        {
            Type type = (Type)id;

            switch (type)
            {
                case Type.BassistRin: return "Bassist Rin";
                case Type.BadGirlRin: return "Bad Girl Rin";
                case Type.SleepwalkerGirlRin: return "Sleepwalker Girl Rin";
                case Type.BunnyGirlRin: return "Bunny Girl Rin";
                case Type.ChristmasGiftRin: return "Christmas Gift Rin";
                case Type.PartTimeWarriorRin: return "Part-Time Warrior Rin";
                case Type.PilotBuro: return "Pilot Buro";
                case Type.IdolBuro: return "Idol Buro";
                case Type.ZombieGirlBuro: return "Zombie Girl Buro";
                case Type.JokerBuro: return "Joker Buro";
                case Type.SailorSuitBuro: return "Sailor Suit Buro";
                case Type.ViolinistMarija: return "Violinist Marija";
                case Type.MaidMarija: return "Maid Marija";
                case Type.MagicalGirlMarija: return "Magical Girl Marija";
                case Type.LittleDevilMarija: return "Little Devil Marija";
                case Type.TheGirlInBlackMarija: return "The Girl In Black Marija";
                case Type.SisterMarija: return "Sister Marija";
                case Type.NavigatorYume: return "Navigator Yume";
                case Type.NEKOOwO: return "NEKO#ΦωΦ";
                case Type.HakureiReimu: return "Hakurei Reimu";
                case Type.ElClear: return "El_Clear";
                default: return id.ToString();
            }
        }
    }
}
