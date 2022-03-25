namespace IM.Application.Exceptions
{
    public class UpdateEntityFailedRepositorySaveException<T> : Exception where T : class
    {
        public override string Message => $"Error: Failed to update entity of type: {typeof(T)} on repository save";
    }
}
