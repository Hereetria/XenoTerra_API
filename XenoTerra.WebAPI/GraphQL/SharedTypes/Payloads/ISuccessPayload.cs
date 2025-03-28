namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads
{
    public interface ISuccessPayload<TResult> : IPayload
        where TResult : class
    {
        TResult Result { get; }
    }
}
