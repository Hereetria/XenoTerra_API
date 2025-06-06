﻿using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Filters
{
    public class PostAdminFilterType : FilterInputType<Post>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Post> descriptor)
        {
        descriptor.Name("PostAdminFilterInput");
        }
    }
}
