using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.RecentChatsQueries.Filters
{
    public class RecentChatsFilterType : FilterInputType<RecentChats>
    {
        protected override void Configure(IFilterInputTypeDescriptor<RecentChats> descriptor)
        {
        }
    }
}
