using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MediaResolvers
{
    public class MediaResolver : EntityResolver<Media, Guid>, IMediaResolver
    {
        public MediaResolver(EntityDataLoaderFactory entityDataLoaderFactory, IMapper mapper)
            : base(entityDataLoaderFactory, mapper) { }
    }
}
