namespace Kerb.AuthTester.Models
{
    public class TicketCacheResponse<T>
    {
        public T Response { get; set; }
        public IntPtr ResponsePointer { get; set; } = IntPtr.Zero;
    }
}
