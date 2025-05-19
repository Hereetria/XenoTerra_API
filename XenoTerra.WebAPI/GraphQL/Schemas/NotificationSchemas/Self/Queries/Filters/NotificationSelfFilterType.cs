using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Filters
{
    public class NotificationSelfFilterType : FilterInputType<Notification>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Notification> descriptor)
        {
        descriptor.Name("NotificationSelfFilterInput");
        }
    }
}
