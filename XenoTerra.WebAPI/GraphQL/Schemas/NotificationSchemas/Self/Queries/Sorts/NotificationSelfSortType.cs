using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Sorts
{
    public class NotificationSelfSortType : SortInputType<Notification>
    {
        protected override void Configure(ISortInputTypeDescriptor<Notification> descriptor)
        {
        descriptor.Name("NotificationSelfSortInput");
        }
    }
}
