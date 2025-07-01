using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations.Payloads
{
    public record CreateUserSettingAdminPayload : Payload<ResultUserSettingAdminDto>;
}
