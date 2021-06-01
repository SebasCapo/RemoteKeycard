using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Gets whether debug messages should be shown.
        /// </summary>
        [Description("Toggle on/off debug messages.")]
        public string WarheadPanelPermission { get; set; } = "CONT_LVL_3";

        /// <summary>
        /// Gets whether debug messages should be shown.
        /// </summary>
        [Description("Toggle on/off debug messages.")]
        public string GeneratorPermission { get; set; } = "ARMORY_LVL_2";
    }
}
