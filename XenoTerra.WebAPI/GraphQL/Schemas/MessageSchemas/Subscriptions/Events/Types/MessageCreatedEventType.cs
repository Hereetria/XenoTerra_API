﻿namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events.Types
{
    public class MessageCreatedEventType : ObjectType<MessageCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageCreatedEvent> descriptor)
        {
        }
    }
}
