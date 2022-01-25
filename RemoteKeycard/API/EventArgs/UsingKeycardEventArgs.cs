using Exiled.API.Features;

namespace RemoteKeycard.API.EventArgs
{
    /// <summary>
    /// Contains all the information before a <see cref="Exiled.API.Features.Player"/> unlocks an object with a keycard.
    /// </summary>
    public class UsingKeycardEventArgs : System.EventArgs
    {
        /// <inheritdoc/>
        public UsingKeycardEventArgs(Player player, System.EventArgs originalEvent, bool isAllowed = true)
        {
            Player = player;
            IsAllowed = isAllowed;
            OriginalEvent = originalEvent;
        }

        /// <summary>
        /// Gets the <see cref="Exiled.API.Features.Player"/> who used a keycard.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Gets or sets whether the object is unlocked.
        /// </summary>
        public bool IsAllowed { get; set; }

        /// <summary>
        /// Gets the original Exiled <see cref="System.EventArgs"/> this is tied to.
        /// </summary>
        public System.EventArgs OriginalEvent { get; }
    }
}
