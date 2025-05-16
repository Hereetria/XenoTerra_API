namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserChangedEventType : ObjectType<UserChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserChangedAdminEvent> descriptor)
        {
        }
    }
}
