﻿using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events.Types
{
    public class CommentOwnDeletedEventType : ObjectType<CommentOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentOwnDeletedEvent> descriptor)
        {
        }
    }
}
