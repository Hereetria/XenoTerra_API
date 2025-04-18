using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries.Filters
{
    public class MessageFilterType : FilterInputType<Message>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Message> descriptor)
        {
        }
    }
}
