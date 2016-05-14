using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Utility
{
    public static class W2Marshal
    {
        public static unsafe void GetStructure<T>(byte[] buffer, int offset, out T obj) where T : struct
        {
            fixed (byte* b = &buffer[offset])
            {
                obj = Marshal.PtrToStructure<T>(new IntPtr(b));
            }
        }

        public static unsafe byte[] GetBytes<T>(T obj) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(obj)];

            fixed (byte* b = buffer)
            {
                Marshal.StructureToPtr(obj, new IntPtr(b), false);

                return buffer;
            }
        }

        public static void CreateZeroInitialized<T>(out T obj) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];

            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = 0;

            GetStructure(buffer, 0, out obj);
        }
    }
}