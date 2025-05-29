using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserSettingSelfSubscription
    {
        [Subscribe]
        public UserSettingSelfCreatedEvent OnUserSettingSelfCreated(
            [EventMessage] UserSettingSelfCreatedEvent evt) => evt;

        [Subscribe]
        public UserSettingSelfUpdatedEvent OnUserSettingSelfUpdated(
            [EventMessage] UserSettingSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public UserSettingSelfDeletedEvent OnUserSettingSelfDeleted(
            [EventMessage] UserSettingSelfDeletedEvent evt) => evt;

        [Subscribe]
        public UserSettingSelfChangedEvent OnUserSettingSelfChanged(
            [EventMessage] UserSettingSelfChangedEvent evt) => evt;
    }
}
