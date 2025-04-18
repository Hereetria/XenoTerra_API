using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries.Sorts
{
    public class MessageSortType : SortInputType<Message>
    {
        protected override void Configure(ISortInputTypeDescriptor<Message> descriptor)
        {
        }
    }
}
