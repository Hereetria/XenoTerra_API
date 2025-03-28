using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class RecentChatsNestedFilterType : FilterInputType<RecentChats>
    {
        protected override void Configure(IFilterInputTypeDescriptor<RecentChats> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.RecentChatsId);
            descriptor.Field(f => f.LastMessage);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.LastMessageAt);
        }
    }
}
