using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationQueries.Filters
{
    public class NotificationFilterType : FilterInputType<Notification>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Notification> descriptor)
        {
        }
    }
}
