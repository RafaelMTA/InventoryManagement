namespace IM.Application.Exceptions
{
    public class RemoveEntityFailedException<T> : Exception where T : class
    {
        public override string Message => $"Error: Failed to remove entity of type: {typeof(T)}";
    }
}
