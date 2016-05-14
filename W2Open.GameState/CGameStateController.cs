using System;
using System.ComponentModel;
using System.Timers;
using W2Open.Common;
using W2Open.Common.Game.v747;
using W2Open.Common.Utility;

namespace W2Open.GameState
{
    public class CGameStateController
    {
        /*
         * TODO: nesta classe devem ficar todos os objetos que representam o canal da "tmsrv".
         * Para cada canal, o caller deve instanciar 1 objeto deste.
         * 
         * Criar coisas como: MobGridMap, SpawnedMobs, etc.
         */

        public readonly DateTime SinceInit;

        public CGameStatistics Statistics { get; private set; }

        public CPlayerConnection[] PlayerConnections { get; set; }
        public CPlayer[] Players { get; set; }

        private Timer m_Timer;

        public CGameStateController(ISynchronizeInvoke syncObj)
        {
            Statistics = new CGameStatistics();

            Players = new CPlayer[NetworkBasics.MAX_PLAYER];
            PlayerConnections = new CPlayerConnection[NetworkBasics.MAX_PLAYER];

            SinceInit = DateTime.Now;

            // Initialize the timer which will fires the 'OnProcessSecTimer' event.
            m_Timer = new Timer() { Interval = 1000, SynchronizingObject = syncObj };
            m_Timer.Elapsed += (sender, e) => OnProcessSecTimer?.Invoke(this);
            m_Timer.Start();
        }

        public delegate EPlayerRequestResult DProcessPacket(CPlayerConnection player);
        public delegate void DProcessSecTimer(CGameStateController gs);

        public static event DProcessPacket OnProcessPacket;
        public static event DProcessSecTimer OnProcessSecTimer;

        /// <summary>
        /// Insert the player in the game state. This method must be called when the player just stablishes a connection by sending the INIT_CODE to the server.
        /// </summary>
        public bool TryInsertPlayerConnection(CPlayerConnection player)
        {
            Statistics.StablishedConnections++;

            short i;
            for (i = 1; i < NetworkBasics.MAX_PLAYER; i++)
            {
                if (PlayerConnections[i] == null || PlayerConnections[i].State == CPlayerConnection.EState.CLOSED)
                    break;
            }

            if (i >= NetworkBasics.MAX_PLAYER)
                return false;

            Statistics.ConnectedPlayers++;

            PlayerConnections[i] = player;
            player.Index = i;

            W2Log.Write($"New connection on id: {player.Index}. IPEP: {player.Tcp.Client.RemoteEndPoint}", ELogType.NETWORK);

            return true;
        }

        /// <summary>
        /// Disconnect the player.
        /// Exceptions:
        ///     Throws any exceptions except the "GameStateException.Code == INVALID_PLAYER_INDEX".
        /// </summary>
        /// <param name="player"></param>
        [Obsolete]
        public void DisconnectPlayer(CPlayerConnection player)
        {
            if (player.State != CPlayerConnection.EState.CLOSED)
            {
                // TODO: send the dced spawn in the visible area around the player.
                // TODO: proceed removind the player of all the game state: mob grid, spawned mobs, etc.

                Statistics.ConnectedPlayers--;

                player.State = CPlayerConnection.EState.CLOSED;

                W2Log.Write($"Connection {player.Index} was disconnected.", ELogType.NETWORK);
            }
        }

        /// <summary>
        /// Process the player requests.
        /// This method fires the <see cref="OnProcessPacket"/> event to be hooked up by plugins.
        /// </summary>
        public EPlayerRequestResult ProcessPlayerRequest(CPlayerConnection player)
        {
            EPlayerRequestResult result = EPlayerRequestResult.NO_ERROR;
            Statistics.ReceivedPackets++;

            BPacketHeader header = player.RecvPacket.Header;

            W2Log.Write(string.Format("New recv packet ({3}) from connection {2} {{0x{0:X}/{1}}}.",
                header.Opcode, header.Size, player.Index, Statistics.ReceivedPackets), ELogType.NETWORK);

            foreach (DProcessPacket target in OnProcessPacket.GetInvocationList())
            {
                result = target(player);

                if (result != EPlayerRequestResult.NO_ERROR && result != EPlayerRequestResult.PACKET_NOT_HANDLED)
                {
                    W2Log.Write("eita", ELogType.CRITICAL_ERROR);
                    break;
                }
            }

            return result;
        }
    }
}