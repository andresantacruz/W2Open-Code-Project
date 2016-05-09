using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v752
{
    public class UItem : IUnmanagedReader, IUnmanagedWriter
    {
        public short Index;
        
        private BEffect[] Effs;

        public UItem()
        {
            Effs = new BEffect[3];
        }

        public int UnmanagedSize => 8;

        public unsafe void ReadFromUnmanaged(byte* pointedBuffer)
        {
            Index = *(short*)&pointedBuffer[0];

            for (int i = 0; i < Effs.Length; i++)
                Effs[i] = *(BEffect*)&pointedBuffer[2 + sizeof(BEffect) * i];
        }

        public unsafe void WriteToUnmanaged(byte* pointedBuffer)
        {
            *(short*)&pointedBuffer[0] = Index;

            for (int i = 0; i < Effs.Length; i++)
                *(BEffect*)&pointedBuffer[2 + sizeof(BEffect) * i] = Effs[i];
        }

        [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
        public struct BEffect
        {
            public sbyte Code;
            public sbyte Value;
        }
    }

    public abstract class ItemCollection : IUnmanagedReader, IUnmanagedWriter
    {
        public UItem[] Items;

        protected ItemCollection(int length)
        {
            if(length < 1)
                throw new ArgumentOutOfRangeException(nameof(length));

            Items = new UItem[length];

            for (int i = 0; i < Items.Length; i++)
                Items[i] = new UItem();
        }

        public int UnmanagedSize => Items[0].UnmanagedSize * Items.Length;

        public unsafe void ReadFromUnmanaged(byte* pointedBuffer)
        {
            for (int i = 0; i < Items.Length; i++)
                Items[i].ReadFromUnmanaged(&pointedBuffer[i * Items[0].UnmanagedSize]);
        }

        public unsafe void WriteToUnmanaged(byte* pointedBuffer)
        {
            for (int i = 0; i < Items.Length; i++)
                Items[i].WriteToUnmanaged(&pointedBuffer[i * Items[0].UnmanagedSize]);
        }
    }
}