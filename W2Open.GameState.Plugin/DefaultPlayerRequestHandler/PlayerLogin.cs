using W2Open.Common.Game.v747;
using W2Open.Common.Game.v747.Packets;
using W2Open.Common.Utility;
using W2Open.DataServer;

namespace W2Open.GameState.Plugin.DefaultPlayerRequestHandler
{
    public class PlayerLogin : IGameStatePlugin
    {
        public void Install()
        {
            CGameStateController.OnProcessPacket += CGameStateController_OnProcessPacket;
        }

        private EPlayerRequestResult CGameStateController_OnProcessPacket(CPlayerConnection playerConn)
        {
            CGameStateController gs = playerConn.GameState;

            switch (playerConn.RecvPacket.Header.Opcode)
            {
                case UPacket_0x20D.Opcode:
                {
                    UPacket_0x20D packet;
                    UPlayerAccount playerAcc;

                    playerConn.RecvPacket.GetPacketStructure(out packet);

                    switch (PlayerAccountCRUD.TryReadAccount(packet.Login, packet.Password, out playerAcc))
                    {
                        case PlayerAccountCRUD.EResult.NO_ERROR:
                        {
                            CPlayer newPlayer = new CPlayer(playerConn, playerAcc);

                            gs.Players[playerConn.Index] = newPlayer;

                            playerConn.SendPacket(new UPacket_0x10E(playerConn.Index, playerAcc));

                            break;
                        }
                        default:
                        {
                            playerConn.SendPacket(new UPacket_0x101("Esta conta não existe."));
                            gs.DisconnectPlayer(playerConn);
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