namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events.Types
{
    public class ViewStoryCreatedEventType : ObjectType<ViewStoryCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryCreatedAdminEvent> descriptor)
        {
        }
    }
}
