using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace W2Open.Common.Game.v747.Packets
{
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK, CharSet = CharSet.Ansi)]
    public struct UPacket_0x20F
    {
        public const int Opcode = 0x20F;

        public BPacketHeader Header;

        public int SlotId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_MOB_NAME)]
        public string Name;

        public int ClassId;
    }
}