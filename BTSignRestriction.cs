using Rocket.API;
using Rocket.Core.Plugins;
using System;
using Logger = Rocket.Core.Logging.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using BTSignRestriction.Helpers.BaseHelpers;

namespace BTSignRestriction
{
    public partial class BTSignRestriction : RocketPlugin<BTSignRectrictionConfiguration>
    {
        public static BTSignRestriction Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("#############################################", ConsoleColor.Yellow);
            Logger.Log("###         BTSignRestriction Loaded      ###", ConsoleColor.Yellow);
            Logger.Log("###   Plugin Created By blazethrower320   ###", ConsoleColor.Yellow);
            Logger.Log("###            Join my Discord:           ###", ConsoleColor.Yellow);
            Logger.Log("###     https://discord.gg/YsaXwBSTSm     ###", ConsoleColor.Yellow);
            Logger.Log("#############################################", ConsoleColor.Yellow);
            BarricadeManager.onModifySignRequested += onModifySignRequested;
        }

        private void onModifySignRequested(CSteamID instigator, InteractableSign sign, ref string text, ref bool shouldAllow)
        {
            var player = UnturnedPlayer.FromCSteamID(instigator);
            if (player.HasPermission(Configuration.Instance.SignRestrictionBypass))
            {
                DebugManager.SendDebugMessage("Player has Bypass Permission");
                shouldAllow = true;
                return;
            }
            if(sign.owner == player.CSteamID && Configuration.Instance.allowEditOwnSgn)
            {
                DebugManager.SendDebugMessage("Allowing Sign Change - Player is owner of sign");
                shouldAllow = true;
                return;
            }
            DebugManager.SendDebugMessage($"{player.CharacterName} attempted to change sign text to: [{text}]");
            TranslationHelper.SendMessageTranslation(player.CSteamID, "UnableToSetText");
            shouldAllow = false;
            if (!Configuration.Instance.NotifyStaffOnTextChange) return;
            foreach(SteamPlayer play in Provider.clients)
            {
                var playr = UnturnedPlayer.FromSteamPlayer(play);
                if (playr.HasPermission(Configuration.Instance.StaffPermission))
                {
                    TranslationHelper.SendMessageTranslation(playr.CSteamID, "StaffNotify", player.CharacterName, text);
                }
            }
        }

        protected override void Unload()
        {
            Logger.Log("BTSignRestriction Unloaded");
            Instance = null;
            BarricadeManager.onModifySignRequested -= onModifySignRequested;
        }
    }
}
