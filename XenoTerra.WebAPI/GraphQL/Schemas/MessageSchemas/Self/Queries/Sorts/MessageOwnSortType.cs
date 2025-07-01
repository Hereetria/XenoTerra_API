using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Sorts
{
    public class MessageOwnSortType : SortInputType<Message>
    {
        protected override void Configure(ISortInputTypeDescriptor<Message> descriptor)
        {
        descriptor.Name("MessageOwnSortInput");
        }
    }
}
