using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Filters
{
    public class MessageFilterType : FilterInputType<Message>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Message> descriptor)
        {
        }
    }
}
