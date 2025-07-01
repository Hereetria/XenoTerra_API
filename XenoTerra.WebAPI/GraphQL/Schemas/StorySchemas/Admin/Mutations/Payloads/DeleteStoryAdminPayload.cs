using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads
{
    public record DeleteStoryAdminPayload : Payload<ResultStoryAdminDto>;
}
