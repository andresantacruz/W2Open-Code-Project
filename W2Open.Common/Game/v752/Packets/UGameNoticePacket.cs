using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace W2Open.Common.Game.v752.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct UGameNoticePacket
    {
        public const int Opcode = 0x101;

        public BPacketHeader Header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 96)]
        public String Message;

        public UGameNoticePacket(String msg)
        {
            Header = BPacketHeader.GetInitialized<UGameNoticePacket>(Opcode, NetworkBasics.SYSTEM_CLIENTID);
            Message = msg;
        }
    }
}