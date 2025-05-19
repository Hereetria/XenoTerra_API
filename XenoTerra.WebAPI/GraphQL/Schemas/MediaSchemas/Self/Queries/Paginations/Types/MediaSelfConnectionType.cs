using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Paginations.Types
{
    public class MediaSelfConnectionType : ObjectType<MediaSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
