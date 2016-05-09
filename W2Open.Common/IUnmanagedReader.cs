namespace W2Open.Common
{
    public interface IUnmanagedReader
    {
        int UnmanagedSize { get; }

        unsafe void ReadFromUnmanaged(byte* pointedBuffer);
    }
}
