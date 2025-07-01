using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Types.Self.Own
{
    public class SearchHistoryWithRelationsOwnType : ObjectType<ResultSearchHistoryWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryWithRelationsOwn");
        }
    }
}
