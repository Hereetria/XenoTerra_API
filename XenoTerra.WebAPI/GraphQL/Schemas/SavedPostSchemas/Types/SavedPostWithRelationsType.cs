using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Types
{
    public class SavedPostWithRelationsType : ObjectType<ResultSavedPostWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSavedPostWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultSavedPostWithRelations");
        }
    }
}
