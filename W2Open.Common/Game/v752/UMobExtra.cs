using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v752
{
    /// <summary>
    /// TODO: lacking fields.
    /// </summary>
    [Obsolete]
    [StructLayout(LayoutKind.Explicit, Pack = ProjectBasics.DEFAULT_PACK, Size = 100)]
    public unsafe struct UMobExtra
    {
        [FieldOffset(0)]
        public short ClassMaster;
    }
}