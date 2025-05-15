namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserUpdatedEventType : ObjectType<UserUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserUpdatedEvent> descriptor)
        {
        }
    }
}
