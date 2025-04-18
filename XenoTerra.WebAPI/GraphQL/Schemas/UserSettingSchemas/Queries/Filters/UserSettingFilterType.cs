using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingQueries.Filters
{
    public class UserSettingFilterType : FilterInputType<UserSetting>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserSetting> descriptor)
        {
        }
    }
}
