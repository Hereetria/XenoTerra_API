namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events.Types
{
    public class AppUserOwnUpdatedEventType : ObjectType<UserOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserOwnUpdatedEvent> descriptor)
        {
        }
    }
}
