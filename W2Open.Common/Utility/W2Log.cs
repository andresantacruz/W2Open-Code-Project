using System;

namespace W2Open.Common.Utility
{
    public enum ELogType
    {
        CRITICAL_ERROR = 0,
        /// <summary>
        /// Represents a game event related log.
        /// </summary>
        GAME_EVENT,
        /// <summary>
        /// Represents a network related log.
        /// </summary>
        NETWORK,
    }

    /// <summary>
    /// Responsible for all kind of work related to logging events.
    /// Events:
    ///     <see cref="DidLog"/>
    /// </summary>
    [Obsolete]
    public static class W2Log
    {
        /// <summary>
        /// Fired when someone writes any log.
        /// </summary>
        public static event Action<string, ELogType> DidLog;

        /// <summary>
        /// Logs a text.
        /// </summary>
        /// <param name="txt">Text to be logged</param>
        /// <param name="logType">Type of the log.</param>
        public static void Write(string txt, ELogType logType)
        {
            // TODO: log the text in the hard disk file.

            DidLog?.Invoke(txt, logType);
        }
    }
}