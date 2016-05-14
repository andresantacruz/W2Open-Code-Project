using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747
{
    /// <summary>
    /// Header present in all the valid game packets.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
    public struct BPacketHeader
    {
        public ushort Size;

        public byte Key;
        public byte CheckSum;

        public ushort Opcode;
        public ushort ClientId;

        public uint TimeStamp;

        public BPacketHeader(ushort opcode, ushort clientId, int size) : this()
        {
            Size = (ushort)size;
            Opcode = opcode;
            ClientId = clientId;
            TimeStamp = (uint)Environment.TickCount;
        }
    }
}