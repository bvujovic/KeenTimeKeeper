namespace KeenTimeKeeper.Classes
{
    public class TaskItem
    {
        public string Name { get; set; } = string.Empty;

        public int TimeInSecs { get; set; } = 0;

        public DateTime LastUsed { get; set; } = DateTime.MinValue;

        public override string ToString()
            => $"{Name} => {TimeInSecs}";

        public string ToValueString()
        {
            return $"{TimeInSecs}|{LastUsed}";
        }

        public void FromValueString(string value)
        {
            var parts = value.Split('|');
            if (parts.Length >= 1)
            {
                if (int.TryParse(parts[0], out int timeInSecs))
                    TimeInSecs = timeInSecs;
            }
            if (parts.Length >= 2)
            {
                if (DateTime.TryParse(parts[1], out DateTime lastUsed))
                    LastUsed = lastUsed;
            }
        }
    }
}
