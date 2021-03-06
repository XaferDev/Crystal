﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.Communication.Realm.Packet
{
    public class PlayerDisconnectedMessage : Protocol.ForwardPacket
    {
        public PlayerDisconnectedMessage(string name)
            : base(Protocol.ForwardPacketTypeEnum.PlayerDisconnectedMessage)
        {
            Writer.Write(name);
        }
    }
}
