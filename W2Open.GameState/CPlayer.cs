using System;
using System.Net.Sockets;
using W2Open.Common;
using W2Open.Common.Utility;
using W2Open.DataServer;

namespace W2Open.GameState
{
    /// <summary>
    /// Represents each connected player.
    /// </summary>
    public class CPlayer
    {
        public short Index { get; set; }

        public EPlayerState State { get; set; }

        public CCompoundBuffer RecvPacket { get; private set; }

        public UPlayerAccount? AccountData { get; set; }

        private NetworkStream m_Stream;

        public CPlayer(NetworkStream _stream)
        {
            m_Stream = _stream;

            Index = -1;
            State = EPlayerState.WAITING_TO_LOGIN;
            RecvPacket = new CCompoundBuffer(NetworkBasics.MAXL_PACKET);
            AccountData = null;
        }

        /// <summary>
        /// Represents the actual state of the player in the game.
        /// </summary>
        public enum EPlayerState
        {
            /// <summary>
            /// Setted when the system asked to shutdown the player.
            /// </summary>
            CLOSED = 0,
            /// <summary>
            /// Waiting to be inserted in the GameController. The player have just been created and don't sent the INIT_CODE packet yet.
            /// </summary>
            WAITING_TO_LOGIN,
            /// <summary>
            /// Setted when the login process have success. The player is in the character selecion step.
            /// </summary>
            SEL_CHAR,
            /// <summary>
            /// Setted when the player picks a character and enters the game world.
            /// </summary>
            AT_WORLD,
        }

        /// <summary>
        /// Send a given game packet to the player.
        /// </summary>
        public void SendPacket<T>(T packet) where T : struct
        {
            if (m_Stream.CanWrite)
            {
                CCompoundBuffer buffer = new CCompoundBuffer(W2Marshal.GetBytes(packet));

                W2PacketSecurity.Encrypt(buffer);

                m_Stream.Write(buffer.RawBuffer, 0, buffer.RawBuffer.Length);

                W2Log.Write(String.Format("A packet were sent to the player (Index: {0}).", Index), ELogType.NETWORK);
            }
        }

        #region Static fields
        public static bool IsValidIndex(int index)
        {
            return index >= 1 && index <= NetworkBasics.MAX_PLAYER;
        }
        #endregion
    }
}