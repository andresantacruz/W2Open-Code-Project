namespace W2Open.Common
{
    /// <summary>
    /// The implementation of a compounded raw byte buffer.
    /// This object encapsulates the process of reading and writing to a byte buffer when this activity is will be done many times.
    /// After instantiating a CCoumpoundBuffer, you read or write in the byte buffer via the Read/Write methods.
    /// </summary>
    public class CCompoundBuffer
    {
        /// <summary>
        /// The raw packet buffer.
        /// </summary>
        public byte[] RawBuffer { get; set; }

        /// <summary>
        /// This variable must be called only in his property!
        /// </summary>
        private int m_Offset;
        /// <summary>
        /// The actual offset to the valid data in the buffer.
        /// </summary>
        public int Offset
        {
            get { return m_Offset; }

            set
            {
                if (value < 0)
                    m_Offset = 0;
                else if (value >= RawBuffer.Length)
                    m_Offset = RawBuffer.Length - 1;
                else
                    m_Offset = value;
            }
        }

        public CCompoundBuffer(byte[] rawBuffer, int initialOffset = 0)
        {
            RawBuffer = rawBuffer;
            Offset = initialOffset;
        }

        public CCompoundBuffer(int bufferLength, int initialOffset = 0)
        {
            RawBuffer = new byte[bufferLength];
            Offset = initialOffset;
        }
    }
}