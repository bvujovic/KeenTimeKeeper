namespace KeenTimeKeeper.Classes
{
    public static class Data
    {
        /// <summary>Update current DataSet from the file</summary>
        /// <param name="dsCurrent">DataSet to update, currently in use (memory)</param>
        /// <remarks>Only tasks are updated; new tasks are not added. Settings are not changed.</remarks>
        public static void UpdateDataSetFromFile(Ds dsCurrent)
        {
            var dsFromFile = new Ds();
            //dsFromFile.ReadXml(GetDataSetFileName());
            dsFromFile.ReadXml(OneDriveData.GetDataSetFilePath());
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
