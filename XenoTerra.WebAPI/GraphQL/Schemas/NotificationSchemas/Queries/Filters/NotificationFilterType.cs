using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationQueries.Filters
{
    public class NotificationFilterType : FilterInputType<Notification>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Notification> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NotificationId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.Message);
            descriptor.Field(f => f.Image);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}
