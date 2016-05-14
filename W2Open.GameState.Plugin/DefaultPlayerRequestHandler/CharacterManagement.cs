using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2Open.Common.Game.v747;
using W2Open.Common.Game.v747.Packets;
using W2Open.Common.Utility;

namespace W2Open.GameState.Plugin.DefaultPlayerRequestHandler
{
    public class CharacterManagement : IGameStatePlugin
    {
        public void Install()
        {
            CGameStateController.OnProcessPacket += CGameStateController_OnProcessPacket; ;
        }

        private unsafe EPlayerRequestResult CGameStateController_OnProcessPacket(CPlayerConnection playerConn)
        {
            EPlayerRequestResult result = EPlayerRequestResult.NO_ERROR;
            CGameStateController gs = playerConn.GameState;

            switch (playerConn.RecvPacket.Header.Opcode)
            {
                case UPacket_0x20F.Opcode:
                {
                    UPacket_0x20F packet;
                    playerConn.RecvPacket.GetPacketStructure(out packet);

                    UPlayerAccount acc = gs.Players[playerConn.Index].AccountData;

                    if(acc.Character[packet.SlotId].Name == string.Empty)
                    {

                    }

                    break;
                }

                default:
                {
                    result = EPlayerRequestResult.PACKET_NOT_HANDLED;
                    break;
                }
            }

            return result;
        }
    }
}