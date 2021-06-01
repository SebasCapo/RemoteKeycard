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
        public static bool CanOpen(this Player player, string perm)
        {
            if(string.IsNullOrEmpty(perm))
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
                    Log.Debug($"{nameof(CanOpen)}(string): {e.Message}\n{e.StackTrace}", RemoteKeycard.Instance.Config.Extras.DebugMode);
                }
            }

            return false;
        }

        public static bool CanOpen(this Player player, DoorVariant door)
        {
            if(door?.RequiredPermissions == null)
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
                    Log.Debug($"{nameof(CanOpen)}(DoorVariant): {e.Message}\n{e.StackTrace}", RemoteKeycard.Instance.Config.Extras.DebugMode);
                }
            }

            return false;
        }
    }
}
