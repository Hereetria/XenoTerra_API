namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserChangedEventType : ObjectType<UserChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserChangedEvent> descriptor)
        {
        }
    }
}
