using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Mutations.Payloads
{
    public record DeleteRecentChatsPayload : Payload<ResultRecentChatsDto>;
}
