using W2Open.Common.Game.v747;
using W2Open.DataServer;

namespace W2Open.GameState
{
    /// <summary>
    /// Represents each connected player.
    /// </summary>
    public class CPlayer
    {
        public CPlayerConnection Connection { get; set; }

        public UPlayerAccount AccountData { get; set; }

        public CPlayer(CPlayerConnection conn, UPlayerAccount acc)
        {
            Connection = conn;
            AccountData = acc;
        }
    }
}