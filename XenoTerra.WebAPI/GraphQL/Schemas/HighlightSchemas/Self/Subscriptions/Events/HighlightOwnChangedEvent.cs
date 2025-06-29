﻿using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events
{
    public record HighlightOwnChangedEvent : ChangedEvent<ResultHighlightOwnDto>
    {
    }
}
