using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v752
{
    /// <summary>
    /// Header present in all the valid game packets.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct BPacketHeader
    {
        public ushort Size;

        public byte Key;
        public byte CheckSum;

        public ushort Opcode;
        public ushort ClientId;

        public uint TimeStamp;
    }
}