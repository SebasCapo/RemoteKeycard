using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Interactables.Interobjects.DoorUtils;

namespace RemoteKeycard.API.Extensions
{
    /// <summary>
    /// A set of extensions used in this plugin.
    /// </summary>
    public static class PlayerExtensions
    {
        private static Config.Config Config => RemoteKeycard.Instance.Config;

        /// <summary>
        /// Checks whether the player has a keycard of a specific permission.
        /// </summary>
        /// <param name="player"><see cref="Player"/> trying to open the door.</param>
        /// <param name="perm">The raw permission for a keycard.</param>
        /// <returns>Whether the player has the requiered keycard.</returns>
        public static bool CanOpen(this Player player, string perm)
        {
            if(string.IsNullOrEmpty(perm))
                return false;

            if(Config.AmnesiaMatters && player.TryGetEffect(Exiled.API.Enums.EffectType.Amnesia, out var effect) && effect.Enabled)
                return false;

            foreach(var item in player.Inventory.items.ToList())
            {
                try
                {
                    if(item.id.IsKeycard() && player.Inventory.GetItemByID(item.id).permissions.Contains(perm))
                    {
                        return true;
                    }
                } catch(Exception e)
                {
                    Log.Debug($"{nameof(CanOpen)}(string): {e.Message}\n{e.StackTrace}", Config.Extras.DebugMode);
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether the player can open/close a specific door.
        /// </summary>
        /// <param name="player"><see cref="Player"/> trying to open the door.</param>
        /// <param name="door">The <see cref="DoorVariant"/> that's being opened/closed.</param>
        /// <returns>Whether the player has the requiered keycard.</returns>
        public static bool CanOpen(this Player player, DoorVariant door)
        {
            if(door?.RequiredPermissions == null || door.NetworkActiveLocks == 0)
                return false;

            if(Config.AmnesiaMatters && player.TryGetEffect(Exiled.API.Enums.EffectType.Amnesia, out var effect) && effect.Enabled)
                return false;

            foreach(var item in player.Inventory.items.ToList())
            {
                try
                {
                    if(item.id.IsKeycard() && door.RequiredPermissions.CheckPermissions(item.id, player.ReferenceHub))
                    {
                        return true;
                    }
                } catch(Exception e)
                {
                    Log.Debug($"{nameof(CanOpen)}(DoorVariant): {e.Message}\n{e.StackTrace}", Config.Extras.DebugMode);
                }
            }

            return false;
        }
    }
}
