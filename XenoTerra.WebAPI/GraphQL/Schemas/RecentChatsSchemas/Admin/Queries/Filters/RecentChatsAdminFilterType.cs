using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Filters
{
    public class RecentChatsAdminFilterType : FilterInputType<RecentChats>
    {
        protected override void Configure(IFilterInputTypeDescriptor<RecentChats> descriptor)
        {
        descriptor.Name("RecentChatsAdminFilterInput");
        }
    }
}
