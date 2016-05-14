using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747.Packets
{
    /// <summary>
    /// Send game notice packet.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
    public struct UPacket_0x101
    {
        public const int Opcode = 0x101;

        public BPacketHeader Header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 96)]
        public string Message;

        public UPacket_0x101(string msg)
        {
            Header = new BPacketHeader(Opcode, W2Basics.SYSTEM_CLIENTID, Marshal.SizeOf(typeof(UPacket_0x101)));
            Message = msg;
        }
    }
}