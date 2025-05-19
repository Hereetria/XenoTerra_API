using Microsoft.AspNetCore.Identity;

namespace XenoTerra.WebAPI.GraphQL.Types.EventTypes
{
    public abstract record BaseEvent<TResult> where TResult : class
    {
        public TResult Result { get; init; } = null!;
        public Guid TriggeredByUserId { get; init; }
        public DateTime OccurredAt { get; init; }
        public string? Source { get; init; }
        public string? CorrelationId { get; init; }

        public static TEvent From<TEvent>(
            TResult result,
            Guid triggeredByUserId,
            DateTime occurredAt,
            string? source = null,
            string? correlationId = null)
            where TEvent : BaseEvent<TResult>, new()
        {
            return new TEvent
            {
                Result = result,
                TriggeredByUserId = triggeredByUserId,
                OccurredAt = occurredAt,
                Source = source,
                CorrelationId = correlationId
            };
        }
    }
}
