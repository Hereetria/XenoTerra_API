using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads
{
    public record UpdateMessageAdminPayload : Payload<ResultMessageAdminDto>;
}
