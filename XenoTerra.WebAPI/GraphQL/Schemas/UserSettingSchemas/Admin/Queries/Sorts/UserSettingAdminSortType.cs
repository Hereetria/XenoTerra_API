using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries.Sorts
{
    public class UserSettingAdminSortType : SortInputType<UserSetting>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserSetting> descriptor)
        {
        descriptor.Name("UserSettingAdminSortInput");
        }
    }
}
