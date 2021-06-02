using Exiled.Events.Extensions;
using RemoteKeycard.API.EventArgs;
using static Exiled.Events.Events;

namespace RemoteKeycard.Handlers
{
    /// <summary>
    /// Handler for this plugin's events.
    /// </summary>
    public static class Events
    {
        /// <inheritdoc cref="UsingKeycardEventArgs"/>
        public static event CustomEventHandler<UsingKeycardEventArgs> UsingKeycard;

        /// <summary>
        /// Safely invokes <see cref="UsingKeycard"/> event.
        /// </summary>
        /// <param name="ev"></param>
        public static void OnUsingKeycard(UsingKeycardEventArgs ev) => UsingKeycard?.InvokeSafely(ev);
    }
}
