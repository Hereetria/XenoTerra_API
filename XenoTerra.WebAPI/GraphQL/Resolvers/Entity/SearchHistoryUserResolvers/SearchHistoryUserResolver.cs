using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.SearchHistoryUserResolvers
{
    public class SearchHistoryUserResolver(
        IEntityFieldMapBuilder<SearchHistoryUser, Guid> entityFieldMapBuilder,
        IDataLoaderInvoker dataLoaderInvoker
    )
        : EntityResolver<SearchHistoryUser, Guid>(entityFieldMapBuilder, dataLoaderInvoker),
          ISearchHistoryUserResolver
    {
    }

}
