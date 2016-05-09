using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v752
{
    /// <summary>
    /// Represents the mob's buffs in the game.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct BAffect
    {
        public byte Type;
        public byte Value;
        public ushort Level;
        public uint Time;
    }
}