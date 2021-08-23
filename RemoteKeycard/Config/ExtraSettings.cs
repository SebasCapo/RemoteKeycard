using System.ComponentModel;

namespace RemoteKeycard.Config
{
    /// <summary>
    /// Settings that most users probably won't care about.
    /// </summary>
    public class ExtraSettings
    {
        /// <summary>
        /// Gets whether debug messages should be shown.
        /// </summary>
        [Description("Toggle on/off debug messages.")]
        public bool DebugMode { get; set; } = false;

        /// <summary>
        /// Whether the events system will be functional.
        /// </summary>
        [Description("Toggle the events system on/off. (Feel free to set this to true if none of your plugins use RemoteKeycard's API, which likely is the case)")]
        public bool DisableEvents { get; set; } = false;
    }
}
