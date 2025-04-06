using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class UserSettingNestedSortType : SortInputType<UserSetting>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserSetting> descriptor)
        {
            descriptor.Name("UserSettingNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.UserSettingId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.IsPrivate);
            descriptor.Field(f => f.ReceiveNotifications);
            descriptor.Field(f => f.ShowActivityStatus);
            descriptor.Field(f => f.LastUpdated);
        }
    }
}
