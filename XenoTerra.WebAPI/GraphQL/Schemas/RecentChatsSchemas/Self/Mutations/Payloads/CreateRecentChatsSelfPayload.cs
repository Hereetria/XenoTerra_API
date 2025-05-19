using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Payloads
{
    public record CreateRecentChatsSelfPayload : Payload<ResultRecentChatsDto>;
}
