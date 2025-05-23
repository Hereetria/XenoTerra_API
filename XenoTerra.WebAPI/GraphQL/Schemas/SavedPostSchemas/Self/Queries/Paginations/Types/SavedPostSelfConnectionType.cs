﻿using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations.Types
{
    public class SavedPostSelfConnectionType : ObjectType<SavedPostSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
