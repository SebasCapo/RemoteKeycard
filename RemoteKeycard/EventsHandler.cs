using System;
using System.Linq;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;
using RemoteKeycard.API.Extensions;
using RemoteKeycard.Handlers;
using Players = Exiled.Events.Handlers.Player;

namespace RemoteKeycard
{
    /// <summary>
    /// Handles all the events this plugin needs to function.
    /// </summary>
    public class EventsHandler
    {
        private Config.Config Config => RemoteKeycard.Instance.Config;

        /// <summary>
        /// Registers all events used.
        /// </summary>
        public void Start()
        {
            Players.InteractingDoor += OnDoorInteract;
            Players.UnlockingGenerator += OnGeneratorUnlock;
            Players.InteractingLocker += OnLockerInteract;
            Players.ActivatingWarheadPanel += OnWarheadUnlock;
        }

        /// <summary>
        /// Unregisters all events used.
        /// </summary>
        public void Stop()
        {
            Players.InteractingDoor -= OnDoorInteract;
            Players.UnlockingGenerator -= OnGeneratorUnlock;
            Players.InteractingLocker -= OnLockerInteract;
            Players.ActivatingWarheadPanel -= OnWarheadUnlock;
        }

        private void OnDoorInteract(InteractingDoorEventArgs ev)
        {
            try
            {
                if(!ev.IsAllowed && ev.Player.CanOpen(ev.Door))
                {
                    var _ev = new API.EventArgs.UsingKeycardEventArgs(ev.Player);

                    Events.OnUsingKeycard(_ev);

                    if(!_ev.IsAllowed)
                        return;

                    ev.IsAllowed = true;
                }

            } catch(Exception e)
            {
                Log.Debug($"{nameof(OnDoorInteract)}: {e.Message}\n{e.StackTrace}", Config.Extras.DebugMode);
            }
        }

        private void OnWarheadUnlock(ActivatingWarheadPanelEventArgs ev)
        {
            try
            {
                if(!ev.IsAllowed && ev.Player.CanOpen(Config.Extras.WarheadPanelPermission))
                {
                    var _ev = new API.EventArgs.UsingKeycardEventArgs(ev.Player);

                    Events.OnUsingKeycard(_ev);

                    if(!_ev.IsAllowed)
                        return;

                    ev.IsAllowed = true;
                }
            } catch(Exception e)
            {
                Log.Debug($"{nameof(OnWarheadUnlock)}: {e.Message}\n{e.StackTrace}", Config.Extras.DebugMode);
            }
        }

        private void OnGeneratorUnlock(UnlockingGeneratorEventArgs ev)
        {
            try
            {
                if(!ev.IsAllowed && ev.Player.CanOpen(Config.Extras.GeneratorPermission))
                {
                    var _ev = new API.EventArgs.UsingKeycardEventArgs(ev.Player);

                    Events.OnUsingKeycard(_ev);

                    if(!_ev.IsAllowed)
                        return;

                    ev.IsAllowed = true;
                }
            } catch(Exception e)
            {
                Log.Debug($"{nameof(OnGeneratorUnlock)}: {e.Message}\n{e.StackTrace}", Config.Extras.DebugMode);
            }
        }

        private void OnLockerInteract(InteractingLockerEventArgs ev)
        {
            try
            {
                if(!ev.IsAllowed && ev.Chamber != null && ev.Player.CanOpen(ev.Chamber.accessToken))
                {
                    var _ev = new API.EventArgs.UsingKeycardEventArgs(ev.Player);

                    Events.OnUsingKeycard(_ev);

                    if(!_ev.IsAllowed)
                        return;

                    ev.IsAllowed = true;
                }
            } catch(Exception e)
            {
                Log.Debug($"{nameof(OnLockerInteract)}: {e.Message}\n{e.StackTrace}", Config.Extras.DebugMode);
            }
        }
    }
}