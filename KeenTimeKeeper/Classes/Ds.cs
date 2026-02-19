using System.Data;
using System.Linq;

namespace KeenTimeKeeper.Classes
{
    partial class Ds
    {
        public partial class TasksDataTable
        {
            public TasksRow? Find(string taskName)
                => this.FirstOrDefault(it => it.Name == taskName);
        }

        public partial class TasksRow
        {
            public override string ToString()
                => $"{Name}, seconds: {TimeInSecs}, last used: {LastUsed}";

            public static string DefaultTaskName => "Task";

            public static int DefaultTaskTimeInSecs => 0;

            public static int DefaultChunkMinutes => 10;
        }

        public partial class SettingsRow
        {
            public override string ToString()
                => $"{Name} => {(IsNull(nameof(Value)) ? "/" : Value)}";
        }
    }
}