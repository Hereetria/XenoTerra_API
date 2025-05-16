using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Paginations.Types
{
    public class MediaAdminConnectionType : ObjectType<MediaAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
