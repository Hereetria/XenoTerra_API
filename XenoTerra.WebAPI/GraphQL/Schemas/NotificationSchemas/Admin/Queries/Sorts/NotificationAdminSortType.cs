using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Sorts
{
    public class NotificationAdminSortType : SortInputType<Notification>
    {
        protected override void Configure(ISortInputTypeDescriptor<Notification> descriptor)
        {
        descriptor.Name("NotificationAdminSortInput");
        }
    }
}
