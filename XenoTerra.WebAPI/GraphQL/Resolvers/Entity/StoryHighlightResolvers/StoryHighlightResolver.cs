using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryHighlightResolvers
{
    public class StoryHighlightResolver(
        IEntityFieldMapBuilder<StoryHighlight, Guid> entityFieldMapBuilder,
        IDataLoaderInvoker dataLoaderInvoker
    )
        : EntityResolver<StoryHighlight, Guid>(entityFieldMapBuilder, dataLoaderInvoker),
          IStoryHighlightResolver
    {
    }

}
