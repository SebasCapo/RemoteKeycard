using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;

namespace RemoteKeycard.Config 
{
    /// <summary>
    /// The plugin's main config file.
    /// </summary>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc cref="ExtraSettings" path="//*[not(self::remarks)]"/>
        [Description("These are some extra settings, mainly for developers, testing and curious people.")]
        public ExtraSettings Extras { get; set; } = new ExtraSettings();
    }
}
