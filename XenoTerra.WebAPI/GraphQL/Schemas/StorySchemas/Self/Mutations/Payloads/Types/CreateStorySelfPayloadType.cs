﻿using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Payloads.Types
{
    public class CreateStorySelfPayloadType : ObjectType<CreateStorySelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateStorySelfPayload> descriptor)
        {
        }
    }
}
