namespace KeenTimeKeeper.Classes
{
    public class Utils
    {
        private static readonly string[] folders = [
            "c:\\Users\\bvnet\\OneDrive\\x\\AppData\\KeenTimeKeeper\\",
            "c:\\Users\\sosos\\OneDrive\\x\\AppData\\KeenTimeKeeper\\"
            ];

        private static int idxFolder = -1;

        public static void SetOneDriveAppFolder()
        {
            for (int i = 0; i < folders.Length; i++)
                if (Directory.Exists(folders[i]))
                    idxFolder = i;
            if (idxFolder == -1)
                throw new Exception("KeenTimeKeeper folder on OneDrive/x is not found.");
        }
        
        private const string dataSetFileName = "dsSettings.xml";

        public static string GetDataSetFileName()
        {
            if (idxFolder == -1)
                SetOneDriveAppFolder();
            return Path.Combine(folders[idxFolder], dataSetFileName);
        }

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

    public enum MinimizeOnStartTime
    {
        Immediately,
        After1Sec,
        After2Secs,
        After5Secs,
        Never
    }
}
