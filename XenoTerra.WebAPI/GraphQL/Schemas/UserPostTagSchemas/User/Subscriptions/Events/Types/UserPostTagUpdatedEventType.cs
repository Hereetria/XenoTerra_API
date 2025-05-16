using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagUpdatedEventType : ObjectType<UserPostTagUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagUpdatedSelfEvent> descriptor)
        {
        }
    }
}
