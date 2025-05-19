using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Payloads
{
    public record DeleteUserSettingSelfPayload : Payload<ResultUserSettingDto>;
}
