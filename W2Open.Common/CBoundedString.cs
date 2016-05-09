using System;

namespace W2Open.Common
{
    public sealed class UBoundedString : IUnmanagedReader, IUnmanagedWriter
    {
        private String m_Value;
        private int m_MaxLength;

        public UBoundedString(int maxLength)
        {
            m_MaxLength = maxLength;
            m_Value = String.Empty;
        }

        public String Value
        {
            get
            {
                return m_Value;
            }

            set
            {
                if (value.Length > UnmanagedSize)
                    m_Value = value.Substring(0, UnmanagedSize);
                else
                    m_Value = value;
            }
        }

        public int UnmanagedSize => m_MaxLength;

        public unsafe void ReadFromUnmanaged(byte* pointedBuffer)
        {
            Value = new String((sbyte*)pointedBuffer, 0, UnmanagedSize);
        }

        public unsafe void WriteToUnmanaged(byte* pointedBuffer)
        {
            for (int i = 0; i < m_Value.Length && i < UnmanagedSize; i++)
                pointedBuffer[i] = (byte)m_Value[i];
        }
    }
}