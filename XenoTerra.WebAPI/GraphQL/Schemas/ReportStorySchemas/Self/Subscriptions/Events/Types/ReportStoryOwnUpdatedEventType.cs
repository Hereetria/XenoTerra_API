using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events.Types
{
    public class ReportStoryOwnUpdatedEventType : ObjectType<ReportStoryOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryOwnUpdatedEvent> descriptor)
        {
        }
    }
}
