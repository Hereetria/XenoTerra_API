using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations.Payloads
{
    public record CreateViewStoryAdminPayload : Payload<ResultViewStoryDto>;
}
