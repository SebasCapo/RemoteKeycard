using System.ComponentModel;
using Exiled.API.Interfaces;

namespace RemoteKeycard
{
    /// <summary>
    /// The plugin's main config file.
    /// </summary>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets whether debug messages should be shown.
        /// </summary>
        public bool Debug { get; set; } = false;

        /// <summary>
        /// Whether Amnesia affects the usage of keycards.
        /// </summary>
        [Description("Whether  Amnesia affects the usage of keycards.")]
        public bool AmnesiaMatters { get; set; } = true;

        /// <summary>
        /// Whether this plugin works on generators.
        /// </summary>
        [Description("Whether this plugin works on generators.")]
        public bool AffectGenerators { get; set; } = true;

        /// <summary>
        /// Whether this plugin works on Warhead's panel.
        /// </summary>
        [Description("Whether this plugin works on Warhead's panel.")]
        public bool AffectWarheadPanel { get; set; } = true;

        /// <summary>
        /// Whether this plugin works on SCP lockers.
        /// </summary>
        [Description("Whether this plugin works on SCP lockers.")]
        public bool AffectScpLockers { get; set; } = true;

        /// <summary>
        /// Whether this plugin works on doors.
        /// </summary>
        [Description("Whether this plugin works on doors.")]
        public bool AffectDoors { get; set; } = true;

        /// <summary>
        /// Gets whether exceptions should be shown.
        /// </summary>
        [Description("Toggle on/off exceptions/errors in console. (Enable this before reporting ANY bugs)")]
        public bool ShowExceptions { get; set; } = false;
    }
}
