namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events.Types
{
    public class ViewStoryDeletedEventType : ObjectType<ViewStoryDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryDeletedAdminEvent> descriptor)
        {
        }
    }
}
