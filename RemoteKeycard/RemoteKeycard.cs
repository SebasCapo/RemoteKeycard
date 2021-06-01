using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using RemoteKeycard.Config;

namespace RemoteKeycard
{
    public class RemoteKeycard : Plugin<Config.Config>
    {

        /// <summary>
        /// Gets a static instance of this class.
        /// </summary>
        public static RemoteKeycard Instance { get; private set; }

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Instance = this;



            base.OnEnabled();
        }

    }
}
