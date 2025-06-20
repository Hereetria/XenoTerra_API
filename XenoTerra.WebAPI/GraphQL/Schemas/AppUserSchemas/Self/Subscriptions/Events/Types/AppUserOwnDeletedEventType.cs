namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events.Types
{
    public class AppUserOwnDeletedEventType : ObjectType<UserOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserOwnDeletedEvent> descriptor)
        {
        }
    }
}
