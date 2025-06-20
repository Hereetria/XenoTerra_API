﻿using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations.Payloads
{
    public record DeleteUserSettingAdminPayload : Payload<ResultUserSettingAdminDto>;
}
