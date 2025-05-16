namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events.Types
{
    public class ViewStoryDeletedEventType : ObjectType<ViewStoryDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryDeletedSelfEvent> descriptor)
        {
        }
    }
}
