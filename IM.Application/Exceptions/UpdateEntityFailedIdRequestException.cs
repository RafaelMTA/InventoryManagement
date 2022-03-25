namespace IM.Application.Exceptions
{
    public class UpdateEntityFailedIdRequestException<T> : Exception where T : class
    {
        public override string Message => $"Error: Failed to update entity of type: {typeof(T)}, invalid request Id from entity to update";
    }
}
