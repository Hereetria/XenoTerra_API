using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class NotificationNestedFilterType : FilterInputType<Notification>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Notification> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NotificationId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.Message);
            descriptor.Field(f => f.Image);
            descriptor.Field(f => f.CreatedAt);
        }
    }
}
