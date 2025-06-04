using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events.Types
{
    public class ReportPostSelfUpdatedEventType : ObjectType<ReportPostSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostSelfUpdatedEvent> descriptor)
        {
        }
    }
}