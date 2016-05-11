using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace W2Open.Common.Game.v752.Packets
{
    [StructLayout(LayoutKind.Explicit, Pack = ProjectBasics.DEFAULT_PACK, Size = 100)]
    public struct ULoginRequestPacket
    {
        public const int Opcode = 0x20D;

        [FieldOffset(0)]
        public BPacketHeader Header;

        [FieldOffset(12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public String Login;

        [FieldOffset(28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public String Password;
    }
}