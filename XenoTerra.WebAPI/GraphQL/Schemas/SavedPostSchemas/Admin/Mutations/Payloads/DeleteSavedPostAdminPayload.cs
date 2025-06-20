using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Payloads
{
    public record DeleteSavedPostAdminPayload : Payload<ResultSavedPostAdminDto>;
}
