using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Utility
{
    public static class W2Marshal
    {
        public static unsafe T GetStructure<T>(byte[] buffer) where T : struct
        {
            fixed (byte* b = buffer)
            {
                return Marshal.PtrToStructure<T>(new IntPtr(b));
            }
        }

        public static unsafe byte[] GetBytes<T>(T obj) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(obj)];

            fixed (byte* b = buffer)
            {
                Marshal.StructureToPtr<T>(obj, new IntPtr(b), false);

                return buffer;
            }
        }

        public static T CreateZeroInitialized<T>() where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];

            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = 0;

            return GetStructure<T>(buffer);
        }
    }
}