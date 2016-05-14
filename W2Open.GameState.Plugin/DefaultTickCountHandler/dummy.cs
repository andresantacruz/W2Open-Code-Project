namespace W2Open.GameState.Plugin.DefaultTickCountHandler
{
    public class dummy : IGameStatePlugin
    {
        public void Install()
        {
            CGameStateController.OnProcessSecTimer += CGameStateController_OnProcessSecTimer;
        }

        private void CGameStateController_OnProcessSecTimer(CGameStateController gs)
        {
            //W2Log.Write("h", ELogType.CRITICAL_ERROR);
        }
    }
}