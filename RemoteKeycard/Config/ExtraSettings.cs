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
        /// Gets whether exceptions should be shown.
        /// </summary>
        [Description("Toggle on/off exceptions/errors in console. (Enable this before reporting ANY bugs)")]
        public bool ShowExceptions { get; set; } = false;

        /// <summary>
        /// Whether the events system will be functional.
        /// </summary>
        [Description("Toggle the events system on/off. (Feel free to set this to false if none of your plugins use RemoteKeycard's API, which is likely the case)")]
        public bool EnableEvents { get; set; } = true;
    }
}
