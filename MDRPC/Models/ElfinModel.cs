namespace MDRPC.Models
{
    public class ElfinModel
    {
        public enum Type
        {
            MioSir = 0,
            Angela = 1,
            Thanatos = 2,
            Rabot233 = 3,
            LittleNurse = 4,
            LittleWitch = 5,
            DragonGirl = 6,
            Lilith = 7,
            DrPaige = 8
        }

        public static string GetName(int id)
        {
            Type type = (Type)id;

            switch (type)
            {
                case Type.MioSir: return "Mio Sir";
                case Type.Angela: return "Angela";
                case Type.Thanatos: return "Thanatos";
                case Type.Rabot233: return "Rabot-233";
                case Type.LittleNurse: return "Little Nurse";
                case Type.LittleWitch: return "Little Witch";
                case Type.DragonGirl: return "Dragon Girl";
                case Type.Lilith: return "Lilith";
                case Type.DrPaige: return "Dr. Paige";
                default: return id.ToString();
            }
        }
    }
}
