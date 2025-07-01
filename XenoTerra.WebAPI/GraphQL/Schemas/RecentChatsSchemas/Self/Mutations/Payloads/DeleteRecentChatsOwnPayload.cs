using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Payloads
{
    public record DeleteRecentChatsOwnPayload : Payload<ResultRecentChatsOwnDto>;
}
