namespace KeenTimeKeeper.Classes
{
    public static class Data
    {
        private static readonly string[] users = ["bvnet", "sosos"];
        private static readonly string[] folders = new string[users.Length];

        static Data()
        {
            for (int i = 0; i < users.Length; i++)
                folders[i] = "c:\\Users\\" + users[i] + "\\OneDrive\\x\\AppData\\KeenTimeKeeper\\";
        }

        //private static readonly string[] folders = [
        //    "c:\\Users\\bvnet\\OneDrive\\x\\AppData\\KeenTimeKeeper\\",
        //    "c:\\Users\\sosos\\OneDrive\\x\\AppData\\KeenTimeKeeper\\"
        //    ];

        // Index of the found OneDrive/x folder in the folders array
        private static int idxFolder = -1;

        /// <summary>Set the OneDrive/x folder index based on existing directories (logged in user)</summary>
        public static void SetOneDriveAppFolder()
        {
            for (int i = 0; i < folders.Length; i++)
                if (Directory.Exists(folders[i]))
                    idxFolder = i;
            if (idxFolder == -1)
                throw new Exception("KeenTimeKeeper folder on OneDrive/x is not found.");
        }

        private const string dataSetFileName = "ds.xml";

        /// <summary>Get full path to the DataSet file: OneDrive\x\AppData\KeenTimeKeeper</summary>
        public static string GetDataSetFileName()
        {
            if (idxFolder == -1)
                SetOneDriveAppFolder();
            return Path.Combine(folders[idxFolder], dataSetFileName);
        }

        /// <summary>Update current DataSet from the file</summary>
        /// <param name="dsCurrent">DataSet to update, currently in use (memory)</param>
        /// <remarks>Only tasks are updated; new tasks are not added. Settings are not changed.</remarks>
        public static void UpdateDataSetFromFile(Ds dsCurrent)
        {
            var dsFromFile = new Ds();
            dsFromFile.ReadXml(GetDataSetFileName());
            foreach (var tc in dsCurrent.Tasks)
            {
                var tf = dsFromFile.Tasks.Find(tc.Name);
                if (tf != null && tf.LastUsed == tc.LastUsed)
                {
                    tc.TimeInSecs = tf.TimeInSecs;
                    tc.ChunkMinutes = tf.ChunkMinutes;
                    tc.LastUsed = tf.LastUsed;
                }
            }
        }
    }
}
