﻿using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events
{
    public record UserPostTagAdminDeletedEvent : DeletedEvent<ResultUserPostTagDto>
    {
    }
}
