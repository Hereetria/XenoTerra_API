using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Types.Admin
{
    public class SearchHistoryAdminType : ObjectType<ResultSearchHistoryAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryAdminDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryAdmin");
        }
    }
}
