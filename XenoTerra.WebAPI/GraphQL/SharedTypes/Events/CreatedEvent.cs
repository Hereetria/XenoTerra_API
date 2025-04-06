namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Events
{
    public abstract record CreatedEvent<TResult> : BaseEvent<TResult> where TResult : class
    {
        public static new TEvent From<TEvent>(
            TResult result,
            Guid triggeredByUserId,
            DateTime occurredAt,
            string? source = null,
            string? correlationId = null)
            where TEvent : CreatedEvent<TResult>, new()
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
