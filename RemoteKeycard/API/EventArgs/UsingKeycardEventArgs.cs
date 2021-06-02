using Exiled.API.Features;

namespace RemoteKeycard.API.EventArgs
{
    /// <summary>
    /// Contains all the information before a <see cref="Exiled.API.Features.Player"/> unlocks an object with a keycard.
    /// </summary>
    public class UsingKeycardEventArgs : System.EventArgs
    {
        /// <inheritdoc/>
        public UsingKeycardEventArgs(Player player, bool isAllowed = true)
        {
            Player = player;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets the <see cref="Exiled.API.Features.Player"/> who used a keycard.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Gets or sets whether the object is unlocked.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}
