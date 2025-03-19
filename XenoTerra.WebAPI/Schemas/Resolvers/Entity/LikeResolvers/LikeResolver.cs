using AutoMapper;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers
{
    public class LikeResolver : EntityResolver<Like, ResultLikeWithRelationsDto, Guid>, ILikeResolver
    {
        public LikeResolver(EntityDataLoaderFactory entityDataLoaderFactory) : base(entityDataLoaderFactory)
        {
        }
    }
}
