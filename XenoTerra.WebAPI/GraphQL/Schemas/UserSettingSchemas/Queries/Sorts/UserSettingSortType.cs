using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingQueries.Sorts
{
    public class UserSettingSortType : SortInputType<UserSetting>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserSetting> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.UserSettingId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.IsPrivate);
            descriptor.Field(f => f.ReceiveNotifications);
            descriptor.Field(f => f.ShowActivityStatus);
            descriptor.Field(f => f.LastUpdated);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
