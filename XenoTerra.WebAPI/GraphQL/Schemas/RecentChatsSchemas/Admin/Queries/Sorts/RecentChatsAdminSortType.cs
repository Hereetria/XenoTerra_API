﻿using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Sorts
{
    public class RecentChatsAdminSortType : SortInputType<RecentChats>
    {
        protected override void Configure(ISortInputTypeDescriptor<RecentChats> descriptor)
        {
        descriptor.Name("RecentChatsAdminSortInput");
        }
    }
}
