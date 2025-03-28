using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class MessageNestedSortType : SortInputType<Message>
    {
        protected override void Configure(ISortInputTypeDescriptor<Message> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.MessageId);
            descriptor.Field(f => f.Content);
            descriptor.Field(f => f.SenderId);
            descriptor.Field(f => f.ReceiverId);
            descriptor.Field(f => f.Header);
            descriptor.Field(f => f.SentAt);
        }
    }
}
