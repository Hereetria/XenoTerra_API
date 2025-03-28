using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads
{
    public abstract record UpdateBlockUserPayload(
        bool Success,
        string Message
    ) : IPayload;

    public sealed record UpdateBlockUserSuccessPayload(
        string Message,
        ResultBlockUserDto BlockUser
    ) : UpdateBlockUserPayload(true, Message), ISuccessPayload<ResultBlockUserDto>
    {
        public ResultBlockUserDto Result => BlockUser;
    }

    public sealed record UpdateBlockUserFailurePayload(
        string Message,
        IReadOnlyList<string> Errors
    ) : UpdateBlockUserPayload(false, Message), IFailurePayload;
}
