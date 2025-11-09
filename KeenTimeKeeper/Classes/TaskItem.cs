namespace KeenTimeKeeper.Classes
{
    public class TaskItem
    {
        public string Name { get; set; } = string.Empty;

        public int TimeInSecs { get; set; } = 0;

        public override string ToString()
            => $"{Name} => {TimeInSecs}";
    }
}
