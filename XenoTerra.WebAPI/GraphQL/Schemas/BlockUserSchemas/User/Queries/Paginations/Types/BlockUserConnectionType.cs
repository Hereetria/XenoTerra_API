using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations.Types
{
    public class BlockUserConnectionType : ObjectType<BlockUserConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
