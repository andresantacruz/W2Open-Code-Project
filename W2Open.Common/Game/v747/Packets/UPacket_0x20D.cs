using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747.Packets
{
    /// <summary>
    /// Player login request packet.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK, Size = 100)]
    public struct UPacket_0x20D
    {
        public const int Opcode = 0x20D;

        public BPacketHeader Header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string Login;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Division;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string Password;

        public short ClientVersion;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public byte[] Addapter;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 52)]
        public string KeyStamp;
    }
}