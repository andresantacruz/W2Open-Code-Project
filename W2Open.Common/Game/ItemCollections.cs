using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using W2Open.Common.Game.v752;

namespace W2Open.Common.Game
{
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct UEquip
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_EQUIP)]
        public UItem[] Items;

        public UItem this[int itemId]
        {
            get { return Items[itemId]; }
            set { Items[itemId] = value; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
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

    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct UCargo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_CARGO)]
        public UItem[] Items;

        public UItem this[int itemId]
        {
            get { return Items[itemId]; }
            set { Items[itemId] = value; }
        }
    }
}
