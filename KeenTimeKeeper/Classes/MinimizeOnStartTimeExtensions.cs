// - Define `ToDisplayString` switch mapping for all members of `MinimizeOnStartTime`.
// - Provide a fallback to `mode.ToString()` to be safe if new enum members are added.

namespace KeenTimeKeeper.Classes
{
    internal static class MinimizeOnStartTimeExtensions
    {
        public static string ToDisplayString(this MinimizeOnStartTime mode)
            => mode switch
            {
                MinimizeOnStartTime.Never => "Never",
                MinimizeOnStartTime.Immediately => "Immediately",
                MinimizeOnStartTime.After1Sec => "After 1 second",
                MinimizeOnStartTime.After2Secs => "After 2 seconds",
                MinimizeOnStartTime.After5Secs => "After 5 seconds",
                _ => mode.ToString()
            };
    }
}