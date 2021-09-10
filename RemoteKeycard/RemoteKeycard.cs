using System;
using Exiled.API.Features;

namespace RemoteKeycard
{
    /// <summary>
    /// The plugin's core class.
    /// </summary>
    public class RemoteKeycard : Plugin<Config.Config>
    {

        /// <summary>
        /// Gets a static instance of this class.
        /// </summary>
        public static RemoteKeycard Instance { get; private set; }

        /// <inheritdoc/>
        public override string Name => "RemoteKeycard";

        /// <inheritdoc/>
        public override string Prefix => "remotekeycard";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        /// <inheritdoc/>
        public override string Author => "Beryl";

        /// <inheritdoc/>
        public override Version Version => new Version(3, 0, 0);

        /// <inheritdoc cref="EventsHandler"/>
        public EventsHandler Handler { get; private set; }

        /// <summary>
        /// Instance initializer.
        /// </summary>
        public RemoteKeycard() => Instance = this;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Log.Debug("Initializing events...", Config.Extras.DebugMode);
            Handler = new EventsHandler(Config);
            Handler.Start();
            Log.Debug("Events initialized successfully.", Config.Extras.DebugMode);

            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Log.Debug("Stopping events...", Config.Extras.DebugMode);
            Handler.Stop();
            Handler = null;
            Log.Debug("Events stopped successfully.", Config.Extras.DebugMode);

            base.OnDisabled();
        }
    }
}
