﻿using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Queries.Filters
{
    public class SearchHistoryUserFilterType : FilterInputType<SearchHistoryUser>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SearchHistoryUser> descriptor)
        {
        }
    }
}
