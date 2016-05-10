using System;
using System.ComponentModel;
using System.Timers;
using W2Open.Common;
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

        public static event DProcessPacket OnProcessPacket;
        public static event DProcessSecTimer OnProcessSecTimer;

        public readonly DateTime SinceInit;
        public CPlayer[] Players { get; set; }

        private Timer m_Timer;

        public CGameStateController(ISynchronizeInvoke syncObj)
        {
            Players = new CPlayer[NetworkBasics.MAX_PLAYER];

            SinceInit = DateTime.Now;

            // Initialize the timer which will fires the 'OnProcessSecTimer' event.
            m_Timer = new Timer() { Interval = 1000, SynchronizingObject = syncObj };
            m_Timer.Elapsed += (sender, e) => OnProcessSecTimer?.Invoke(this);
            m_Timer.Start();
        }

        public delegate EPlayerRequestResult DProcessPacket(CGameStateController gs, CPlayer player);
        public delegate void DProcessSecTimer(CGameStateController gs);

        /// <summary>
        /// Insert the player in the game state. This method must be called when the player just stablishes a connection by sending the INIT_CODE to the server.
        /// </summary>
        public bool TryInsertPlayer(CPlayer player)
        {
            short i;
            for (i = 1; i < NetworkBasics.MAX_PLAYER; i++)
            {
                if (Players[i] == null || Players[i].State == EPlayerState.CLOSED)
                    break;
            }

            if (i >= NetworkBasics.MAX_PLAYER)
                return false;

            player.Index = i;

            return true;
        }

        /// <summary>
        /// Disconnect the player.
        /// Exceptions:
        ///     Throws any exceptions except the "GameStateException.Code == INVALID_PLAYER_INDEX".
        /// </summary>
        /// <param name="player"></param>
        [Obsolete]
        public void DisconnectPlayer(CPlayer player)
        {
            if (player.State != EPlayerState.CLOSED)
            {
                // TODO: send the dced spawn in the visible area around the player.
                // TODO: proceed removind the player of all the game state: mob grid, spawned mobs, etc.

                player.State = EPlayerState.CLOSED;

                W2Log.Write($"The player {player.Index} was disconnected from the server.", ELogType.GAME_EVENT);
            }
        }

        /// <summary>
        /// Process the player requests.
        /// This method fires the <see cref="OnProcessPacket"/> event to be hooked up by plugins.
        /// </summary>
        public EPlayerRequestResult ProcessPlayerRequest(CPlayer player)
        {
            EPlayerRequestResult result = EPlayerRequestResult.NO_ERROR;

            foreach (DProcessPacket target in OnProcessPacket.GetInvocationList())
            {
                result = target(this, player);

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