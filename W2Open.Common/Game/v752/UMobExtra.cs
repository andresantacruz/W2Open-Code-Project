using System;

namespace W2Open.Common.Game.v752
{
    /// <summary>
    /// TODO: lacking fields.
    /// </summary>
    [Obsolete]
    public class UMobExtra : IUnmanagedReader, IUnmanagedWriter
    {
        public short ClassMaster { get; set; }

        public UMobExtra()
        {
        }

        public int UnmanagedSize => 0;

        public unsafe void ReadFromUnmanaged(byte* pointedBuffer)
        {
            ClassMaster = *(short*)&pointedBuffer[0];
        }

        public unsafe void WriteToUnmanaged(byte* pointedBuffer)
        {
            // TODO: remove this zero-initalization loop after completing this method.
            for (int i = 0; i < UnmanagedSize; i++)
                pointedBuffer[i] = 0;

            *(short*)&pointedBuffer[0] = ClassMaster;
        }
    }
}
