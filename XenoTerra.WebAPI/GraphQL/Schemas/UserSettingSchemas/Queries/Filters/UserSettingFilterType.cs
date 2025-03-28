using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingQueries.Filters
{
    public class UserSettingFilterType : FilterInputType<UserSetting>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserSetting> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.UserSettingId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.IsPrivate);
            descriptor.Field(f => f.ReceiveNotifications);
            descriptor.Field(f => f.ShowActivityStatus);
            descriptor.Field(f => f.LastUpdated);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}
