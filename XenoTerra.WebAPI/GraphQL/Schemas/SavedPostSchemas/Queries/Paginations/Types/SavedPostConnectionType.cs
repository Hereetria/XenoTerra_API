﻿namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Queries.Paginations.Types
{
    public class SavedPostConnectionType : ObjectType<SavedPostConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
