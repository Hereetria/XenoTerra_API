using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Types.Self.Own
{
    public class SavedPostWithRelationsOwnType : ObjectType<ResultSavedPostWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSavedPostWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultSavedPostWithRelationsOwn");
        }
    }
}
