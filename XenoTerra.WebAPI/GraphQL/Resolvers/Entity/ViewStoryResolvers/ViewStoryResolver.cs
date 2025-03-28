using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers
{
    public class ViewStoryResolver : EntityResolver<ViewStory, Guid>, IViewStoryResolver
    {
        public ViewStoryResolver(IEntityFieldMapBuilder<ViewStory, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
 