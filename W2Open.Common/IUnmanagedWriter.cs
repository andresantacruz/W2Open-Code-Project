namespace W2Open.Common
{
    public interface IUnmanagedWriter
    {
        int UnmanagedSize { get; }

        unsafe void WriteToUnmanaged(byte* pointedBuffer);
    }
}
