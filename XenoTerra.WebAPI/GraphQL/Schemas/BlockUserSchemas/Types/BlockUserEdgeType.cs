using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Edges;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types
{
    public class BlockUserEdgeType : ObjectType<BlockUserEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserEdge> descriptor)
        {
            descriptor.Field(x => x.Node)
                .Type<NonNullType<BlockUserType>>();

            descriptor.Field(x => x.Cursor)
                .Type<NonNullType<StringType>>();
        }
    }
}
