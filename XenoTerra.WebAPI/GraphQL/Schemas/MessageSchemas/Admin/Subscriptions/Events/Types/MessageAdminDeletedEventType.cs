﻿using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageAdminDeletedEventType : ObjectType<MessageAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageAdminDeletedEvent> descriptor)
        {
        }
    }
}
