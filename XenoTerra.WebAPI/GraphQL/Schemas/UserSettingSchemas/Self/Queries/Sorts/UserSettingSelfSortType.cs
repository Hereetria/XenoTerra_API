using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Sorts
{
    public class UserSettingSelfSortType : SortInputType<UserSetting>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserSetting> descriptor)
        {
        descriptor.Name("UserSettingSelfSortInput");
        }
    }
}
