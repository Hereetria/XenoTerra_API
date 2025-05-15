using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries.Sorts
{
    public class UserSettingSortType : SortInputType<UserSetting>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserSetting> descriptor)
        {
        }
    }
}
