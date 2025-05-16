namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserDeletedEventType : ObjectType<UserDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserDeletedSelfEvent> descriptor)
        {
        }
    }
}
