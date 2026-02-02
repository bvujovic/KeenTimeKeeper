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

        partial class SettingsDataTable
        {
            //public void SaveSetting(string group, string name, string? value)
            //{
            //    SaveSetting($"{group}.{name}", value);
            //}

            /// <summary>Read list values from the group</summary>
            /// <example>
            /// TN.RAF:600
            /// TN.prog:0
            ///</example>
            //public List<SettingsRow> ReadGroup(string group)
            //{
            //    var list = new List<SettingsRow>();
            //    var prefix = $"{group}.";
            //    foreach (SettingsRow s in Rows)
            //        if (s.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            //        {
            //            var t = NewSettingsRow();
            //            t.Name = s.Name[prefix.Length..];
            //            t.Value = s.Value;
            //            list.Add(t);
            //            //s.Name = s.Name[prefix.Length..];
            //            //list.Add(s);
            //        }
            //    return list;
            //}

            //public void SaveGroup(string group, List<SettingsRow> list)
            //{
            //    var prefix = $"{group}.";
            //    // remove old
            //    var toRemove = new List<SettingsRow>();
            //    foreach (SettingsRow s in Rows)
            //        if (s.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            //            toRemove.Add(s);
            //    foreach (var s in toRemove)
            //        RemoveSettingsRow(s);
            //    // add new
            //    foreach (var s in list)
            //        SaveSetting($"{group}.{s.Name}", s.Value);
            //}

            //public void WriteSetting(string name, string? value)
            //{
            //    var sett = FindByName(name);
            //    if (sett == null)
            //    {
            //        sett = NewSettingsRow();
            //        sett.Name = name;
            //    }
            //    if (value != null)
            //    {
            //        sett.Value = value;
            //        if (sett.RowState == DataRowState.Detached)
            //            AddSettingsRow(sett);
            //    }
            //    //? this code might not be necessary
            //    else if (sett.RowState != DataRowState.Detached)
            //        RemoveSettingsRow(sett);
            //}

            //public int ReadInt(string name, int defValue, Func<int, bool>? checkMethod = null)
            //{
            //    var s = FindByName(name);
            //    if (s != null)
            //    {
            //        var val = int.Parse(s.Value);
            //        if (checkMethod == null)
            //            return val;
            //        else
            //            return checkMethod(val) ? val : defValue;
            //    }
            //    return defValue;
            //}

            //public bool ReadBool(string name, bool defValue)
            //{
            //    var s = FindByName(name);
            //    if (s != null)
            //        return bool.Parse(s.Value);
            //    return defValue;
            //}

            //public string? ReadString(string name, string? defValue = null)
            //{
            //    var s = FindByName(name);
            //    if (s != null)
            //        return s.Value;
            //    return defValue;
            //}
        }
    }
}