using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Types.Admin
{
    public class SearchHistoryUserWithRelationsAdminType : ObjectType<ResultSearchHistoryUserWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryUserWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryUserWithRelationsAdmin");
        }
    }
}
