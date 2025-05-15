using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Sorts
{
    public class MessageSortType : SortInputType<Message>
    {
        protected override void Configure(ISortInputTypeDescriptor<Message> descriptor)
        {
        }
    }
}
