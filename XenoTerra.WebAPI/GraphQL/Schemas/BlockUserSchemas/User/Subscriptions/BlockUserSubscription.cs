using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class BlockUserSubscription
    {
        [Subscribe]
        public BlockUserCreatedEvent OnBlockUserCreated(
            [EventMessage] BlockUserCreatedEvent evt) => evt;

        [Subscribe]
        public BlockUserUpdatedEvent OnBlockUserUpdated(
            [EventMessage] BlockUserUpdatedEvent evt) => evt;

        [Subscribe]
        public BlockUserDeletedEvent OnBlockUserDeleted(
            [EventMessage] BlockUserDeletedEvent evt) => evt;

        [Subscribe]
        public BlockUserChangedEvent OnBlockUserChanged(
            [EventMessage] BlockUserChangedEvent evt) => evt;
    }
}
