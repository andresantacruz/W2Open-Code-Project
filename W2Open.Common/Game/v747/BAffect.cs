using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747
{
    /// <summary>
    /// Represents the mob's buffs in the game.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
    public struct BAffect
    {
        public byte Type;
        public byte Value;
        public ushort Level;
        public uint Time;
    }
}