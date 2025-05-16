namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserUpdatedEventType : ObjectType<UserUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserUpdatedSelfEvent> descriptor)
        {
        }
    }
}
