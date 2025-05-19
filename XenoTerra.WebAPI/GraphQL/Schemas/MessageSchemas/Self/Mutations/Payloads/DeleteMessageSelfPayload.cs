using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Payloads
{
    public record DeleteMessageSelfPayload : Payload<ResultMessageDto>;
}
