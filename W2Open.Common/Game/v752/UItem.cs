using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v752
{
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK, Size = 8)]
    public struct UItem
    {
        public const int MAX_ITEM_EFFECT = 3;
        
        public short Index;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ITEM_EFFECT)]
        private BEffect[] m_Effs;

        [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
        public struct BEffect
        {
            public sbyte Code;
            public sbyte Value;
        }
    }

    public static class ItemHelper
    {
        public static List<int> FindItemsFromIndex(this UItem[] arr, int index)
        {
            List<int> ids = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Index == index)
                    ids.Add(i);
            }

            return ids;
        }
    }
}