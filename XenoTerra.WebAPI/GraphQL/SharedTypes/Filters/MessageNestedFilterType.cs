using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class MessageNestedFilterType : FilterInputType<Message>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Message> descriptor)
        {
            descriptor.Name("MessageNestedFilterInput");
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
