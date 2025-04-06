using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class RecentChatsNestedSortType : SortInputType<RecentChats>
    {
        protected override void Configure(ISortInputTypeDescriptor<RecentChats> descriptor)
        {
            descriptor.Name("RecentChatsNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.RecentChatsId);
            descriptor.Field(f => f.LastMessage);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.LastMessageAt);
        }
    }
}
