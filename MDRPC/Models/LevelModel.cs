namespace MDRPC.Models
{
    public class LevelModel
    {
        public enum Type
        {
            Easy = 1,
            Hard = 2,
            Master = 3
        }

        public static string GetDescription(int difficulty, string level)
        {
            Type type = (Type)difficulty;

            switch (type)
            {
                case Type.Easy: return $"Easy {level}⭐";
                case Type.Hard: return $"Hard {level}⭐";
                case Type.Master: return $"Master {level}⭐";
                default: return "???";
            }
        }
    }
}
