﻿using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Payloads.Types
{
    public class DeleteNoteOwnPayloadType : ObjectType<DeleteNoteOwnPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteNoteOwnPayload> descriptor)
        {
        }
    }
}
