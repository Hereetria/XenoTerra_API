using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries.Filters
{
    public class MessageFilterType : FilterInputType<Message>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Message> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.MessageId);
            descriptor.Field(f => f.Content);
            descriptor.Field(f => f.SenderId);
            descriptor.Field(f => f.ReceiverId);
            descriptor.Field(f => f.Header);
            descriptor.Field(f => f.SentAt);

            descriptor.Field(f => f.Sender)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Receiver)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Reactions)
                .Type<ReactionNestedFilterType>();
        }
    }
}
