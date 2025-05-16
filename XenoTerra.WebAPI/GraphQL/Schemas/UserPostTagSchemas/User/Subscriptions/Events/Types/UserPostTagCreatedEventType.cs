using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagCreatedEventType : ObjectType<UserPostTagCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagCreatedSelfEvent> descriptor)
        {
        }
    }
}
