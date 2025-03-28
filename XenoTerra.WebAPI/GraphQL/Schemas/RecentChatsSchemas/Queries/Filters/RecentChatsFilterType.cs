using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.RecentChatsQueries.Filters
{
    public class RecentChatsFilterType : FilterInputType<RecentChats>
    {
        protected override void Configure(IFilterInputTypeDescriptor<RecentChats> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.RecentChatsId);
            descriptor.Field(f => f.LastMessage);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.LastMessageAt);

            descriptor.Field(f => f.Users)
                .Type<UserNestedFilterType>();
        }
    }
}
