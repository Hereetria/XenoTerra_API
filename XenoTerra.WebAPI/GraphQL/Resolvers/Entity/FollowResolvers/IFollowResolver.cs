﻿using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers
{
    public interface IFollowResolver : IEntityResolver<Follow, Guid>
    {
    }
}
