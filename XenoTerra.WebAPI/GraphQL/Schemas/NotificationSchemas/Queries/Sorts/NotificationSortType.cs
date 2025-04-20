using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries.Sorts
{
    public class NotificationSortType : SortInputType<Notification>
    {
        protected override void Configure(ISortInputTypeDescriptor<Notification> descriptor)
        {
        }
    }
}
