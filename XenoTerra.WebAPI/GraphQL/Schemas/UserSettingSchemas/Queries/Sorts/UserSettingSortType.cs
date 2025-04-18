using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingQueries.Sorts
{
    public class UserSettingSortType : SortInputType<UserSetting>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserSetting> descriptor)
        {
        }
    }
}
