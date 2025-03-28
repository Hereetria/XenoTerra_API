namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads
{
    public interface IPayload
    {
        bool Success { get; }
        string Message { get; }
    }
}
