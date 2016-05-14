using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747
{
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK, Size = 8)]
    public struct UItem
    {        
        public short Index;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_ITEM_EFFECT)]
        private BEffect[] m_Effs;

        [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
        public struct BEffect
        {
            public sbyte Code;
            public sbyte Value;
        }
    }
}