using System.Runtime.InteropServices;
using W2Open.Common;
using W2Open.Common.Game.v752.Packets;
using W2Open.Common.Utility;
using W2Open.DataServer;

namespace W2Open.GameState.Plugin.DefaultPlayerRequestHandler
{
    public struct HandlePlayerLogin : IGameStatePlugin
    {
        public void Install()
        {
            CGameStateController.OnProcessPacket += CGameStateController_OnProcessPacket;
        }

        private EPlayerRequestResult CGameStateController_OnProcessPacket(CGameStateController gs, CPlayerConnection playerConn)
        {
            switch (playerConn.RecvPacket.Header.Opcode)
            {
                case ULoginRequestPacket.Opcode:
                {
                    ULoginRequestPacket packet = W2Marshal.GetStructure<ULoginRequestPacket>(playerConn.RecvPacket.RawBuffer);
                    UPlayerAccount playerAcc;
                    
                    switch(PlayerAccountCRUD.TryRead(packet.Login, packet.Password, out playerAcc))
                    {
                        case PlayerAccountCRUD.EResult.NO_ERROR:
                        {
                            CPlayer newPlayer = new CPlayer(playerConn, playerAcc);

                            gs.Players[playerConn.Index] = newPlayer;

                            break;
                        }
                    }

                    return EPlayerRequestResult.NO_ERROR;
                }

                default: return EPlayerRequestResult.PACKET_NOT_HANDLED;
            }
        }
    }
}