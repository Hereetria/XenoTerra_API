using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.MediaResolvers
{
    public class MediaResolver : EntityResolver<Media, Guid>, IMediaResolver
    {
        public MediaResolver(IEntityFieldMapBuilder<Media, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
