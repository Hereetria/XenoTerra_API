using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Sorts
{
    public class RecentChatsOwnSortType : SortInputType<RecentChats>
    {
        protected override void Configure(ISortInputTypeDescriptor<RecentChats> descriptor)
        {
        descriptor.Name("RecentChatsOwnSortInput");
        }
    }
}
