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
                    AccountCRUD.EResult accErr = AccountCRUD.TryRead(packet.AccName, out nAccFile);

                    if (accErr != AccountCRUD.EResult.NO_ERROR)
                    {
                        // if account doesn't exist...
                        if(accErr == AccountCRUD.EResult.ACC_NOT_FOUND)
                        {
                            // create a new account file
                            MAccountFile newAccFile = W2Marshal.CreateEmpty<MAccountFile>();
                            // set the username & password
                            newAccFile.Info.LoginInfo.AccName = packet.AccName;
                            newAccFile.Info.LoginInfo.Password = packet.Password;

                            AccountCRUD.EResult createAccErr = AccountCRUD.TrySaveAccount(ref newAccFile);

                            if(createAccErr == AccountCRUD.EResult.NO_ERROR)
                            {
                                accErr = AccountCRUD.TryRead(packet.AccName, out nAccFile);

                                if (accErr != AccountCRUD.EResult.NO_ERROR)
                                    return EPlayerRequestResult.UNKNOWN;
                            }
                            else if (createAccErr == AccountCRUD.EResult.ACC_NOT_SAVED)
                            {
                                MTextMessagePacket createFailedAnswer =
                                    W2Marshal.GetEmptyValid<MTextMessagePacket>(MTextMessagePacket.Opcode);

                                createFailedAnswer.Message = "Não foi possível criar a conta.";

                                player.SendPacket(createFailedAnswer);

                                return EPlayerRequestResult.NO_ERROR;
                            }
                            else if (createAccErr == AccountCRUD.EResult.UNKNOWN)
                            {
                                return EPlayerRequestResult.UNKNOWN;
                            }
                        }
                        else
                        {
                            return EPlayerRequestResult.UNKNOWN;
                        }
                    }

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
                
                    
                    return EPlayerRequestResult.NO_ERROR;
                }

                default: return EPlayerRequestResult.PACKET_NOT_HANDLED;
            }
        }
    }
}