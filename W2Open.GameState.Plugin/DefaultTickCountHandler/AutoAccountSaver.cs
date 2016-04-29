using System;
using W2Open.Common.Utility;
using W2Open.DataServer;

namespace W2Open.GameState.Plugin.DefaultTickCountHandler
{
    public class AutoAccountSaver : IGameStatePlugin
    {
        /// <summary>
        /// Used to automatically save online players account.
        /// </summary>
        private DateTime m_LastGlobalAccSave;
        private readonly TimeSpan m_GlobalAccSaveDueTime;

        public AutoAccountSaver()
        {
            m_LastGlobalAccSave = DateTime.Now;
            m_GlobalAccSaveDueTime = new TimeSpan(0, 0, 8); // The auto-save must occur every 8 seconds.
        }

        public void Install()
        {
            CGameStateController.OnProcessSecTimer += CGameStateController_OnProcessSecTimer;
        }

        private void CGameStateController_OnProcessSecTimer(CGameStateController gs)
        {
            if (DateTime.Now - m_LastGlobalAccSave >= m_GlobalAccSaveDueTime)
            {
                for (int i = 0; i < gs.Players.Length; i++)
                {
                    if (gs.Players[i]?.State == EPlayerState.AT_WORLD)
                    {
                        var account = gs.Players[i].AccountData.Value;

                        if (AccountCRUD.TrySaveAccount(ref account) != AccountCRUD.EResult.NO_ERROR)
                        {
                            // TODO: the account could not be saved for some reason.
                            // Do something...
                            throw new Exception($"The account {gs.Players[i].AccountData.Value.Info.LoginInfo.AccName} couldn't be saved.");
                        }
                        else
                        {
                            W2Log.Write($"The account {gs.Players[i].AccountData.Value.Info.LoginInfo.AccName} was saved successfuly.", ELogType.GAME_EVENT);
                        }
                    }
                }

                m_LastGlobalAccSave = gs.SinceInit;
            }
        }
    }
}