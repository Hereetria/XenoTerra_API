using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.CommentResolvers;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class CommentResolver : EntityResolver<Comment, Guid>, ICommentResolver
    {
        public CommentResolver(EntityDataLoaderFactory entityDataLoaderFactory, IMapper mapper)
            : base(entityDataLoaderFactory, mapper) { }
    }

}
