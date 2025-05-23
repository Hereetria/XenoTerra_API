﻿using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.SearchHistoryResolvers
{
    public class SearchHistoryResolver(IEntityFieldMapBuilder<SearchHistory, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : EntityResolver<SearchHistory, Guid>(entityFieldMapBuilder, dataLoaderInvoker), ISearchHistoryResolver
    {
    }

}
