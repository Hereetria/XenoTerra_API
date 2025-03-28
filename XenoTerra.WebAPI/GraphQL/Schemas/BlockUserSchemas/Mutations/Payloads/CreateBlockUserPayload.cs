using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads
{
    public abstract record CreateBlockUserPayload(
        bool Success,
        string Message
    ) : IPayload;

    public sealed record CreateBlockUserSuccessPayload(
        string Message,
        ResultBlockUserDto BlockUser
    ) : CreateBlockUserPayload(true, Message), ISuccessPayload<ResultBlockUserDto>
    {
        public ResultBlockUserDto Result => BlockUser;
    }

    public sealed record CreateBlockUserFailurePayload(
        string Message,
        IReadOnlyList<string> Errors
    ) : CreateBlockUserPayload(false, Message), IFailurePayload;
}
