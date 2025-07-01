using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Types.Self.Own
{
    public class SavedPostOwnType : ObjectType<ResultSavedPostOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSavedPostOwnDto> descriptor)
        {
            descriptor.Name("ResultSavedPostOwn");
        }
    }
}
