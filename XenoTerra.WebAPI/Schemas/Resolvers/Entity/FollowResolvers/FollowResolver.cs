using AutoMapper;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers
{
    public class FollowResolver : EntityResolver<Follow, ResultFollowWithRelationsDto, Guid>, IFollowResolver
    {
        public FollowResolver(EntityDataLoaderFactory entityDataLoaderFactory) : base(entityDataLoaderFactory)
        {
        }
    }
}
