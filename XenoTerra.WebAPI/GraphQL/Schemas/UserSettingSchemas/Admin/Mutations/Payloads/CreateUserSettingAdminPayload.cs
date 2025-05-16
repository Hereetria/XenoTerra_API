using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Payloads
{
    public record CreateUserSettingAdminPayload : Payload<ResultUserSettingDto>;
}
