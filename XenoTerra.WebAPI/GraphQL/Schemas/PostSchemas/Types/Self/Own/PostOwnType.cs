using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types.Self.Own
{
    public class PostOwnType : ObjectType<ResultPostOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostOwnDto> descriptor)
        {
            descriptor.Name("ResultPostOwn");
        }
    }
}
