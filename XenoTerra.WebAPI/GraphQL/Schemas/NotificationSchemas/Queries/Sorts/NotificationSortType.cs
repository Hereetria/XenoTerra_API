using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationQueries.Sorts
{
    public class NotificationSortType : SortInputType<Notification>
    {
        protected override void Configure(ISortInputTypeDescriptor<Notification> descriptor)
        {
        }
    }
}
