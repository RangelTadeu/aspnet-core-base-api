namespace aspnet_core_base_api.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) { }
    }
}
