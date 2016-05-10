using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v752
{
    /// <summary>
    /// The character class in the game
    /// </summary>
    public enum EMobClass : byte
    {
        /// <summary>
        /// Trans Knight.
        /// </summary>
        TK = 0,
        /// <summary>
        /// Foema.
        /// </summary>
        FM = 1,
        /// <summary>
        /// Beast Master.
        /// </summary>
        BM = 2,
        /// <summary>
        /// Huntress.
        /// </summary>
        HT = 3
    }

    /// <summary>
    /// TODO: lacking fields.
    /// </summary>
    [Obsolete]
    [StructLayout(LayoutKind.Explicit, Pack = ProjectBasics.DEFAULT_PACK, Size = 756)]
    public struct UMobBase
    {
        public const int MAX_NAME_LENGTH = 16;

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        public String Name;
    }
}