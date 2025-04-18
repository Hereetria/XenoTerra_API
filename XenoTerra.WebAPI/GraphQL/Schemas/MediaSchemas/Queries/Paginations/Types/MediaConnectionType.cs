namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Queries.Paginations.Types
{
    public class MediaConnectionType : ObjectType<MediaConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
