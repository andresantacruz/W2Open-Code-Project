using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v752
{
    /// <summary>
    /// Represents a 4-byte bidimensional position in the game.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct BPosition
    {
        public short X;
        public short Y;
    }
}