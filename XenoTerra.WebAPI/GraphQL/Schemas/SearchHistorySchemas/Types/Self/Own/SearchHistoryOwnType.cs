using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Types.Self.Own
{
    public class SearchHistoryOwnType : ObjectType<ResultSearchHistoryOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryOwnDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryOwn");
        }
    }
}
