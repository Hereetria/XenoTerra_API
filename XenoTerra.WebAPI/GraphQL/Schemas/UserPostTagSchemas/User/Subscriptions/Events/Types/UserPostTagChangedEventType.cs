using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagChangedEventType : ObjectType<UserPostTagChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagChangedSelfEvent> descriptor)
        {
        }
    }
}
