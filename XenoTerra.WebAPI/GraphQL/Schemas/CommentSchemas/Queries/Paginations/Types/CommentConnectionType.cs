﻿namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Queries.Paginations.Types
{
    public class CommentConnectionType : ObjectType<CommentConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
