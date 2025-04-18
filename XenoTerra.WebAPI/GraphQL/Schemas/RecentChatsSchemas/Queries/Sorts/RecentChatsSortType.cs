using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.RecentChatsQueries
{
    public class RecentChatsSortType : SortInputType<RecentChats>
    {
        protected override void Configure(ISortInputTypeDescriptor<RecentChats> descriptor)
        {
        }
    }
}
