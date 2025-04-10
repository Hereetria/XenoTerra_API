using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Types.Paginations
{
    public class BlockUserConnectionType : ObjectType<BlockUserConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserConnection> descriptor)
        {
            descriptor.Name("BlockUserConnection");

            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
