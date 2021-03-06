﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.World.Handlers
{
    public class NpcHandler
    {
        public static void RegisterMethod()
        {
            Network.Dispatcher.RegisteredMethods.Add("DC", typeof(NpcHandler).GetMethod("InitDialog"));
            Network.Dispatcher.RegisteredMethods.Add("DV", typeof(NpcHandler).GetMethod("ExitDialog"));
        }

        public static void InitDialog(World.Network.WorldClient client, string packet)
        {
            if (!client.Action.IsOccuped)
            {
                Database.Records.NpcPositionRecord Npc = client.Character.Map.Engine.GetNpc(int.Parse(packet.Substring(2)));
                if (Npc != null)
                {
                    Database.Records.NpcDialogRecord Dialog = Helper.NpcHelper.GetDialog(Npc.Template.InitQuestion);
                    if (Dialog != null)
                    {
                        client.State = Network.WorldClientState.OnDialog;
                        client.Send("DCK" + int.Parse(packet.Substring(2)));
                        client.Send("DQ" + Dialog.ID + "|" + Dialog.Responses.Replace(",", ";"));
                    }
                    else
                    {
                        client.Send("BN");
                    }
                }
                else
                {
                    client.Send("BN");
                }
            }
            else
            {
                client.Send("BN");
            }
        }

        public static void ExitDialog(World.Network.WorldClient client, string packet = "")
        {
            client.State = Network.WorldClientState.None;
            client.Send("DV");
        }
    }
}
