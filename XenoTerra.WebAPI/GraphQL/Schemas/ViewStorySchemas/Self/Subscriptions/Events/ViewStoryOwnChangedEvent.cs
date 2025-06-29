﻿using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events
{
    public record ViewStoryOwnChangedEvent : ChangedEvent<ResultViewStoryOwnDto>
    {
    }
}
