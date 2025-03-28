using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries.Sorts
{
    public class MessageSortType : SortInputType<Message>
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

            descriptor.Field(f => f.Sender)
                .Type<UserNestedSortType>();

            descriptor.Field(f => f.Receiver)
                .Type<UserNestedSortType>();
        }
    }
}
