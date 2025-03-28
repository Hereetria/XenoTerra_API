using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationQueries.Sorts
{
    public class NotificationSortType : SortInputType<Notification>
    {
        protected override void Configure(ISortInputTypeDescriptor<Notification> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NotificationId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.Message);
            descriptor.Field(f => f.Image);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
