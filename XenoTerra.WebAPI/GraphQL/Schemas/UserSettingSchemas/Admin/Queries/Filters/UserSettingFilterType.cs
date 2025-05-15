using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries.Filters
{
    public class UserSettingFilterType : FilterInputType<UserSetting>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserSetting> descriptor)
        {
        }
    }
}
