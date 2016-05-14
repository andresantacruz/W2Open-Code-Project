using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace W2Open.Common.Game.v747
{
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
    public struct UInventory
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_INVENTORY)]
        public UItem[] Items;

        public UItem this[int itemId]
        {
            get { return Items[itemId]; }
            set { Items[itemId] = value; }
        }
    }
}
