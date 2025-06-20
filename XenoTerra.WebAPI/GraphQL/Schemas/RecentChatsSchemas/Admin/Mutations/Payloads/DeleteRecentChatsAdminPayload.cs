using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Payloads
{
    public record DeleteRecentChatsAdminPayload : Payload<ResultRecentChatsAdminDto>;
}
