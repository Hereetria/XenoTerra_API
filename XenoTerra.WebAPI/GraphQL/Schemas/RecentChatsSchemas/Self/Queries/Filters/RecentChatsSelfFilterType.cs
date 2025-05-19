using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Filters
{
    public class RecentChatsSelfFilterType : FilterInputType<RecentChats>
    {
        protected override void Configure(IFilterInputTypeDescriptor<RecentChats> descriptor)
        {
        descriptor.Name("RecentChatsSelfFilterInput");
        }
    }
}
