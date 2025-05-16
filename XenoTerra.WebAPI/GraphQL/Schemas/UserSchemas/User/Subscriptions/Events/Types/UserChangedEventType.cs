namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserChangedEventType : ObjectType<UserChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserChangedSelfEvent> descriptor)
        {
        }
    }
}
