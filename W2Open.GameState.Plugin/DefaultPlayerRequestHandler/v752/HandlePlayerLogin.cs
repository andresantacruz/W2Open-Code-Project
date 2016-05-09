using W2Open.Common;
using W2Open.Common.GameStructure;
using W2Open.Common.IncomingPacketStructure;
using W2Open.Common.OutgoingPacketStructure;
using W2Open.Common.Utility;
using W2Open.DataServer;

namespace W2Open.GameState.Plugin.DefaultPlayerRequestHandler
{
    public class HandlePlayerLogin : IGameStatePlugin
    {
        public void Install()
        {
            CGameStateController.OnProcessPacket += CGameStateController_OnProcessPacket;
            CGameStateController.OnProcessSecTimer += CGameStateController_OnProcessSecTimer;
        }

        private void CGameStateController_OnProcessSecTimer(CGameStateController gs)
        {
            W2Log.Write("wat", ELogType.GAME_EVENT);
        }

        private EPlayerRequestResult CGameStateController_OnProcessPacket(CGameStateController gs, CPlayer player)
        {
            switch (player.RecvPacket.ReadNextUShort(4))
            {
                case MAccountLoginPacket.Opcode:
                {
                    if (player.State != EPlayerState.WAITING_TO_LOGIN)
                        return EPlayerRequestResult.PLAYER_INCONSISTENT_STATE;

                    MAccountLoginPacket packet = W2Marshal.GetStructure<MAccountLoginPacket>(player.RecvPacket);

                    MAccountFile? nAccFile;
                    PlayerAccountCRUD.EResult accErr = PlayerAccountCRUD.TryRead(packet.AccName, out nAccFile);

                    if (accErr == PlayerAccountCRUD.EResult.NO_ERROR)
                    {
                        MLoginSuccessfulPacket answer =
                            W2Marshal.GetEmptyValid<MLoginSuccessfulPacket>(MLoginSuccessfulPacket.Opcode);

                        MAccountFile accFile = nAccFile.Value;

                        answer.AccName = accFile.Info.LoginInfo.AccName;
                        answer.Cargo = accFile.Cargo;
                        answer.CargoCoin = accFile.CargoCoin;

                        for (int i = 0; i < GameBasics.MAXL_ACC_MOB; i++)
                        {
                            unsafe
                            {
                                answer.SelChar.Coin[i] = accFile.MobCore[i].Coin;
                                answer.SelChar.Equip[i] = accFile.MobCore[i].Equip;
                                answer.SelChar.Exp[i] = accFile.MobCore[i].Exp;
                                answer.SelChar.Guild[i] = accFile.MobCore[i].Guild;
                                answer.SelChar.Name[i] = accFile.MobCore[i].Name;
                                answer.SelChar.Score[i] = accFile.MobCore[i].BaseScore;
                                answer.SelChar.SPosX[i] = accFile.MobCore[i].StellarGemPosition.X;
                                answer.SelChar.SPosY[i] = accFile.MobCore[i].StellarGemPosition.Y;
                            }
                        }

                        player.SendPacket(answer);

                        player.State = EPlayerState.SEL_CHAR;
                    }
                    else if (accErr == PlayerAccountCRUD.EResult.ACC_NOT_FOUND)
                    {
                        MTextMessagePacket answer =
                            W2Marshal.GetEmptyValid<MTextMessagePacket>(MTextMessagePacket.Opcode);

                        answer.Message = "Esta conta não foi encontrada.";

                        player.SendPacket(answer);
                    }
                    else
                    {
                        return EPlayerRequestResult.UNKNOWN;
                    }

                    return EPlayerRequestResult.NO_ERROR;
                }

                default: return EPlayerRequestResult.PACKET_NOT_HANDLED;
            }
        }
    }
}