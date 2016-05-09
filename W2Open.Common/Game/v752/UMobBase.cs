using System;

namespace W2Open.Common.Game.v752
{
    /// <summary>
    /// The character class in the game
    /// </summary>
    public enum EMobClass : byte
    {
        /// <summary>
        /// Trans Knight.
        /// </summary>
        TK = 0,
        /// <summary>
        /// Foema.
        /// </summary>
        FM = 1,
        /// <summary>
        /// Beast Master.
        /// </summary>
        BM = 2,
        /// <summary>
        /// Huntress.
        /// </summary>
        HT = 3
    }

    /// <summary>
    /// TODO: lacking fields.
    /// </summary>
    [Obsolete]
    public class UMobBase : IUnmanagedReader, IUnmanagedWriter
    {
        public UBoundedString Name { get; set; }

        public UMobBase()
        {
            Name = new UBoundedString(16);
        }

        public int UnmanagedSize => 0;

        public unsafe void ReadFromUnmanaged(byte* pointedBuffer)
        {
            throw new NotImplementedException();
        }

        public unsafe void WriteToUnmanaged(byte* pointedBuffer)
        {
            throw new NotImplementedException();
        }
    }
}
