using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.StoryResolvers
{

    public class StoryResolver : EntityResolver<Story, Guid>, IStoryResolver
    {
        public StoryResolver(IEntityFieldMapBuilder<Story, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
