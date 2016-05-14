using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747
{
    /// <summary>
    /// Represents a 4-byte bidimensional position in the game.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
    public struct BPosition
    {
        public short X;
        public short Y;
    }
}