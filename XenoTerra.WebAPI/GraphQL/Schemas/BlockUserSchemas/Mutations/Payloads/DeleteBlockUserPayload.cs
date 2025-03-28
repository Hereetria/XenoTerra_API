using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads
{
    public abstract record DeleteBlockUserPayload(
        bool Success,
        string Message
    ) : IPayload;

    public sealed record DeleteBlockUserSuccessPayload(
        string Message
    ) : DeleteBlockUserPayload(true, Message);

    public sealed record DeleteBlockUserFailurePayload(
        string Message,
        IReadOnlyList<string> Errors
    ) : DeleteBlockUserPayload(false, Message), IFailurePayload;
}
