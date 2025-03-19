using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers
{
    public class PostResolver : EntityResolver<Post, ResultPostWithRelationsDto, Guid>, IPostResolver
    {
        public PostResolver(EntityDataLoaderFactory entityDataLoaderFactory) : base(entityDataLoaderFactory)
        {
        }
    }
}
