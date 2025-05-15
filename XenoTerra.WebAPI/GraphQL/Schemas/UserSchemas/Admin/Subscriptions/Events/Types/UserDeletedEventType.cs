namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserDeletedEventType : ObjectType<UserDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserDeletedEvent> descriptor)
        {
        }
    }
}
