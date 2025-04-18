using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Types
{
    public class SavedPostType : ObjectType<ResultSavedPostDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSavedPostDto> descriptor)
        {
            descriptor.Name("ResultSavedPost");
        }
    }
}
