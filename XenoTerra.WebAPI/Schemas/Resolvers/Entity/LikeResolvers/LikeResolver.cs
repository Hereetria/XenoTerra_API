﻿using AutoMapper;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers
{
    public class LikeResolver : EntityResolver<Like, ResultLikeWithRelationsDto, Guid>, ILikeResolver
    {
        public LikeResolver(IEntityFieldMapBuilder<Like, ResultLikeWithRelationsDto, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
