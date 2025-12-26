namespace KeenTimeKeeper.Classes
{
    public class Utils
    {
        public static string SecsToMS(int totalSecs)
        {
            int mins = totalSecs / 60;
            int secs = totalSecs % 60;
            if(mins < 60)
                return $"{mins:D2}:{secs:D2}";
            else
            {
                int hours = mins / 60;
                mins %= 60;
                return $"{hours}:{mins:D2}:{secs:D2}";
            }
        }
    }
}
