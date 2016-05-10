using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Utility
{
    public static class W2Marshal
    {
        public static unsafe T GetStructure<T>(byte[] buffer) where T : struct
        {
            fixed(byte* b = buffer)
            {
                return Marshal.PtrToStructure<T>(new IntPtr(b));
            }
        }

        public static unsafe byte[] GetBytes<T>(T obj) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(obj)];

            fixed(byte* b = buffer)
            {
                Marshal.StructureToPtr<T>(obj, new IntPtr(b), false);

                return buffer;
            }
        }
    }
}