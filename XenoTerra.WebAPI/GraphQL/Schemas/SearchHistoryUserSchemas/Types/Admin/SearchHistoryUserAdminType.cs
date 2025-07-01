using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Types.Admin
{
    public class SearchHistoryUserAdminType : ObjectType<ResultSearchHistoryUserAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSearchHistoryUserAdminDto> descriptor)
        {
            descriptor.Name("ResultSearchHistoryUserAdmin");
        }
    }
}
