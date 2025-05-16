using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class BlockUserAdminSubscription
    {
        [Subscribe]
        public BlockUserCreatedAdminEvent OnBlockUserCreated(
            [EventMessage] BlockUserCreatedAdminEvent evt) => evt;

        [Subscribe]
        public BlockUserUpdatedAdminEvent OnBlockUserUpdated(
            [EventMessage] BlockUserUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public BlockUserDeletedAdminEvent OnBlockUserDeleted(
            [EventMessage] BlockUserDeletedAdminEvent evt) => evt;

        [Subscribe]
        public BlockUserChangedAdminEvent OnBlockUserChanged(
            [EventMessage] BlockUserChangedAdminEvent evt) => evt;
    }
}
