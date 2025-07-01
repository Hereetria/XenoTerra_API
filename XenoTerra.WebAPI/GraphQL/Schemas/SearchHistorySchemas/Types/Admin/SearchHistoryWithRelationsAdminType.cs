using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Types.Admin
{
    public class SearchHistoryWithRelationsAdminType : ObjectType<ResultSearchHistoryWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryWithRelationsAdmin");
        }
    }
}
