using System;
using System.Linq;
using CustomPlayerEffects;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Interactables.Interobjects.DoorUtils;
using ExiledPermissions = Exiled.API.Enums.KeycardPermissions;

namespace RemoteKeycard.API.Extensions
{
    /// <summary>
    /// A set of extensions used in this plugin.
    /// </summary>
    public static class PlayerExtensions
    {
        /// <summary>
        /// Checks whether the player has a keycard of a specific permission.
        /// </summary>
        /// <param name="player"><see cref="Player"/> trying to interact.</param>
        /// <param name="permissions">The permission that's gonna be searched for.</param>
        /// <returns>Whether the player has the requiered keycard.</returns>
        public static bool HasKeycardPermission(this Player player, KeycardPermissions permissions)
        {
            if(RemoteKeycard.Instance.Config.AmnesiaMatters && player.GetEffectActive<Amnesia>())
                return false;

            return player.Items.Any(item => item is Keycard keycard && (keycard.Base.Permissions & permissions) != 0);
        }
    }
}
