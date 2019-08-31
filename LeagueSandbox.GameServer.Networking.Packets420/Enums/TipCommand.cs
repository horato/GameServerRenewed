using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum TipCommand : byte
    {
        ActivateTip = 0,
        RemoveTip = 1,
        EnableTipEvents = 2,
        DisableTipEvents = 3,
        ActivateTipDialogue = 4,
        EnableTipDialogueEvents = 5,
        DisableTipDialogueEvents = 6
    }
}
