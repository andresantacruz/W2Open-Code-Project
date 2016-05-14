using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace W2Open.Common.Game.v747.Packets
{
    /// <summary>
    /// Send the first selchar after login.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class UPacket_0x10E
    {
        public BPacketHeader Header;

        public UCharList CharList;

        public UCargo Cargo;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_LOGIN)]
        public string UserName;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Unknow_1816;

        public UPacket_0x10E(UPlayerAccount acc)
        {
            CharList = new UCharList(acc);

            Cargo = acc.Cargo;

            UserName = acc.Login;

            Unknow_1816 = new Byte[8];
        }
    }
}