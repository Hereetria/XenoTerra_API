using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers
{
    public class LikeResolver : EntityResolver<Like, Guid>, ILikeResolver
    {
        public LikeResolver(EntityDataLoaderFactory entityDataLoaderFactory, IMapper mapper)
            : base(entityDataLoaderFactory, mapper) { }
    }
}
