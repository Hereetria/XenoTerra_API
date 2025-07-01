using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Payloads
{
    public record DeleteStoryLikeAdminPayload : Payload<ResultStoryLikeAdminDto>;
}
