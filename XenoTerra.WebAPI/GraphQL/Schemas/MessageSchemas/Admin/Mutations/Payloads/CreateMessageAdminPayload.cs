using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads
{
    public record CreateMessageAdminPayload : Payload<ResultMessageAdminDto>;
}
