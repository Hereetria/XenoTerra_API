﻿using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateSavedPostAdminPayloadType : ObjectType<CreateSavedPostAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateSavedPostAdminPayload> descriptor)
        {
        }
    }
}
