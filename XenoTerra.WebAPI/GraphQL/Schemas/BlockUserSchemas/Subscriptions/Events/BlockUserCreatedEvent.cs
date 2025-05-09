﻿using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions.Events
{
    public record BlockUserCreatedEvent : CreatedEvent<ResultBlockUserDto>
    {
    }
}
