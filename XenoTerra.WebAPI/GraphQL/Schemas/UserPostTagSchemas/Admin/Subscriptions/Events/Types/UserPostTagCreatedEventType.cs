using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagCreatedEventType : ObjectType<UserPostTagCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagCreatedAdminEvent> descriptor)
        {
        }
    }
}
