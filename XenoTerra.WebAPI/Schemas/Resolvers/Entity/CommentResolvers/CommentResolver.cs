using AutoMapper;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.CommentResolvers;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class CommentResolver : EntityResolver<Comment, ResultCommentWithRelationsDto, Guid>, ICommentResolver
    {
        public CommentResolver(EntityDataLoaderFactory entityDataLoaderFactory) : base(entityDataLoaderFactory)
        {
        }
    }
}
