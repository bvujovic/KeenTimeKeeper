namespace KeenTimeKeeper.Classes
{
    public class TimerKeeper
    {
        public int TotalSeconds { get; set; }

        public int ElapsedSeconds { get; set; } = 0;

        //public bool IsStarted { get; set; } = false;
        private bool isStarted = false;
        public bool IsStarted { 
            get => isStarted;
            set
            {
                isStarted = value;
                if (!isStarted)
                    ElapsedSeconds = 0;
            }
        }

        public int ParseTime(string s, bool acceptTime)
        {
            if (string.IsNullOrEmpty(s))
                throw new Exception("Time cannot be empty");
            else
            {
                var parts = s.Split(':');
                if (parts.Length != 2)
                    throw new Exception("Time format should be 00:00");
                int secs = int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
                if (acceptTime)
                    TotalSeconds = secs;
                return secs;
            }
        }

        public string PrintTime()
            => PrintTime(TotalSeconds - ElapsedSeconds);

        public static string PrintTime(int secs)
        {
            int min = secs / 60;
            int sec = secs % 60;
            return $"{min:00}:{sec:00}";
        }

        public void Tick()
        {
            ElapsedSeconds++;
            if (ElapsedSeconds >= TotalSeconds)
            {
                IsStarted = false;
                ElapsedSeconds = 0;
                //ElapsedSeconds = TotalSeconds;
            }
        }
    }
}
