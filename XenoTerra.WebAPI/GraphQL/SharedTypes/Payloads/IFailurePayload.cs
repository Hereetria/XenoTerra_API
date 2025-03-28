namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads
{
    public interface IFailurePayload : IPayload
    {
        IReadOnlyList<string> Errors { get; }
    }
}
