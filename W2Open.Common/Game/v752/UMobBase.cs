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
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_MOB_NAME)]
        public String Name;

        [Obsolete]
        [FieldOffset(100)]
        public UEquip Equip;

        [Obsolete]
        [FieldOffset(200)]
        public UInventory Inventory;
    }
}