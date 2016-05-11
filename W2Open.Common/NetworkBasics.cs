namespace W2Open.Common
{
    /// <summary>
    /// Contains the basic definitions related to the server's network connection.
    /// </summary>
    public static class NetworkBasics
    {
        /// <summary>
        /// Max packet length in bytes.
        /// </summary>
        public const int MAXL_PACKET = 8000;

        /// <summary>
        /// Code used in the game network protocol to initiate the connection. Every player must send this 4-byte value as the first packet.
        /// </summary>
        public const int INIT_CODE = 0x1F11F311;

        /// <summary>
        /// Max simultaneous connected amount of players.
        /// </summary>
        public const int MAX_PLAYER = 500;

        public const int SYSTEM_CLIENTID = 0;
    }
}