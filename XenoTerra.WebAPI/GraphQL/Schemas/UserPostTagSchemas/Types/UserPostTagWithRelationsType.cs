using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types
{
    public class UserPostTagWithRelationsType : ObjectType<ResultUserPostTagWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultUserPostTagWithRelations");
        }
    }
}
