using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations.Types
{
    public class PostConnectionType : ObjectType<PostConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
