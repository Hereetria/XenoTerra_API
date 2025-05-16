using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class BlockUserSelfSubscription
    {
        [Subscribe]
        public BlockUserCreatedSelfEvent OnBlockUserCreated(
            [EventMessage] BlockUserCreatedSelfEvent evt) => evt;

        [Subscribe]
        public BlockUserUpdatedSelfEvent OnBlockUserUpdated(
            [EventMessage] BlockUserUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public BlockUserDeletedSelfEvent OnBlockUserDeleted(
            [EventMessage] BlockUserDeletedSelfEvent evt) => evt;

        [Subscribe]
        public BlockUserChangedSelfEvent OnBlockUserChanged(
            [EventMessage] BlockUserChangedSelfEvent evt) => evt;
    }
}
