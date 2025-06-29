﻿using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events
{
    public record StoryLikeOwnDeletedEvent : DeletedEvent<ResultStoryLikeOwnDto>
    {
    }
}
