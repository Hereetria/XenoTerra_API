﻿using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events
{
    public record HighlightAdminChangedEvent : ChangedEvent<ResultHighlightAdminDto>
    {
    }
}
