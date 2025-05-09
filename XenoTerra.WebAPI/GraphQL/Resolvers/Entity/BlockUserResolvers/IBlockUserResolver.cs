﻿using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers
{
    public interface IBlockUserResolver : IEntityResolver<BlockUser, Guid>
    {
    }
}
