using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class UserSettingNestedFilterType : FilterInputType<UserSetting>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserSetting> descriptor)
        {
            descriptor.Name("UserSettingNestedFilterInput");
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
