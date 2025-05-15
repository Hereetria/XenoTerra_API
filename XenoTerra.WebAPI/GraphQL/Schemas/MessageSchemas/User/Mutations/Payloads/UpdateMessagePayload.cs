using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads
{
    public record UpdateMessagePayload : Payload<ResultMessageDto>;
}
