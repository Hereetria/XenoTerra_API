using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class NotificationNestedSortType : SortInputType<Notification>
    {
        protected override void Configure(ISortInputTypeDescriptor<Notification> descriptor)
        {
            descriptor.Name("NotificationNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NotificationId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.Message);
            descriptor.Field(f => f.Image);
            descriptor.Field(f => f.CreatedAt);
        }
    }
}
