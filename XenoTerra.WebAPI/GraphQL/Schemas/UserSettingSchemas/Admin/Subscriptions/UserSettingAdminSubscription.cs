using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class UserSettingAdminSubscription
    {
        [Subscribe]
        public UserSettingAdminCreatedEvent OnUserSettingAdminCreated(
            [EventMessage] UserSettingAdminCreatedEvent evt) => evt;

        [Subscribe]
        public UserSettingAdminUpdatedEvent OnUserSettingAdminUpdated(
            [EventMessage] UserSettingAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public UserSettingAdminDeletedEvent OnUserSettingAdminDeleted(
            [EventMessage] UserSettingAdminDeletedEvent evt) => evt;

        [Subscribe]
        public UserSettingAdminChangedEvent OnUserSettingAdminChanged(
            [EventMessage] UserSettingAdminChangedEvent evt) => evt;
    }
}
