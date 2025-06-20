using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events.Types
{
    public class ReportPostOwnCreatedEventType : ObjectType<ReportPostOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostOwnCreatedEvent> descriptor)
        {
        }
    }
}