using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Filters
{
    public class UserSettingOwnFilterType : FilterInputType<UserSetting>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserSetting> descriptor)
        {
        descriptor.Name("UserSettingOwnFilterInput");
        }
    }
}
