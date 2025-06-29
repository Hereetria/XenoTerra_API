﻿using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events
{
    public record BlockUserAdminChangedEvent : ChangedEvent<ResultBlockUserAdminDto>
    {
    }
}
