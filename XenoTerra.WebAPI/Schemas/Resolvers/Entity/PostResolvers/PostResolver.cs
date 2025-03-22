using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers
{
    public class PostResolver : EntityResolver<Post, ResultPostWithRelationsDto, Guid>, IPostResolver
    {
        public PostResolver(IEntityFieldMapBuilder<Post, ResultPostWithRelationsDto, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
