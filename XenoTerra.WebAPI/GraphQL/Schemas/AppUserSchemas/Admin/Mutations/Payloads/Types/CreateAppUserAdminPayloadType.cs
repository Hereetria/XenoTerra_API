﻿using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateUserAdminPayloadType : ObjectType<CreateUserAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateUserAdminPayload> descriptor)
        {
        }
    }
}
