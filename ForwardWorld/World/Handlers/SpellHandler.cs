﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.World.Handlers
{
    public static class SpellHandler
    {
        public static void RegisterMethod()
        {
            Network.Dispatcher.RegisteredMethods.Add("SB", typeof(SpellHandler).GetMethod("BoostSpell"));
            Network.Dispatcher.RegisteredMethods.Add("SM", typeof(SpellHandler).GetMethod("MoveSpell"));
        }

        public static void BoostSpell(Network.WorldClient client, string packet)
        {
            int spellID = int.Parse(packet.Substring(2));
            if (client.Character.Spells.HaveSpell(spellID))
            {
                Game.Spells.WorldSpell spell = client.Character.Spells.GetSpell(spellID);
                if (spell.Level < 6 && client.Character.SpellPoint >= spell.Level)
                {
                    if (spell.Level == 5 && client.Character.Level < (spell.Level + 100)) { return; }
                    client.Character.SpellPoint -= spell.Level;
                    spell.Level++;
                    client.Send("SUK" + spellID + "~" + spell.Level);
                    client.Character.Stats.RefreshStats();
                }              
            }
        }

        public static void MoveSpell(Network.WorldClient client, string packet)
        {
            string[] data = packet.Substring(2).Split('|');
            int spellID = int.Parse(data[0]);
            int newPos = int.Parse(data[1]);
            if (client.Character.Spells.HaveSpell(spellID))
            {
                Game.Spells.WorldSpell spell = client.Character.Spells.GetSpell(spellID);
                Game.Spells.WorldSpell spellAtPos = client.Character.Spells.GetSpellAtPos(newPos);
                if (spellAtPos != null)
                {
                    spellAtPos.Position = -1;
                }
                spell.Position = newPos;
            }
        }
    }
}
