using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagDeletedEventType : ObjectType<UserPostTagDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagDeletedEvent> descriptor)
        {
        }
    }
}
