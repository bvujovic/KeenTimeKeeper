namespace KeenTimeKeeper.Classes
{
    internal static class Extensions
    {
        /// <summary>User-friendly strings for MinimizeOnStartTime enum members</summary>
        /// <remarks>Switch mapping for all members of `MinimizeOnStartTime`</remarks>
        public static string ToDisplayString(this MinimizeOnStartTime mode)
            => mode switch
            {
                MinimizeOnStartTime.Never => "Never",
                MinimizeOnStartTime.Immediately => "Immediately",
                MinimizeOnStartTime.After1Sec => "After 1 second",
                MinimizeOnStartTime.After2Secs => "After 2 seconds",
                MinimizeOnStartTime.After5Secs => "After 5 seconds",
                // Fallback to `mode.ToString()` to be safe if new enum members are added.
                _ => mode.ToString()
            };
    }
}