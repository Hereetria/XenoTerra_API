using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Filters
{
    public class MessageOwnFilterType : FilterInputType<Message>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Message> descriptor)
        {
        descriptor.Name("MessageOwnFilterInput");
        }
    }
}
