﻿using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Payloads
{
    public record DeleteNotificationAdminPayload : Payload<ResultNotificationAdminDto>;
}
