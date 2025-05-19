namespace XenoTerra.WebAPI.GraphQL.Types.EventTypes
{
    public abstract record DeletedEvent<TResult> : BaseEvent<TResult> where TResult : class
    {
        public TResult PreviousState
        {
            get => Result;
            init => Result = value;
        }

        public static new TEvent From<TEvent>(
            TResult previousState,
            Guid triggeredByUserId,
            DateTime occurredAt,
            string? source = null,
            string? correlationId = null)
            where TEvent : DeletedEvent<TResult>, new()
        {
            return new TEvent
            {
                PreviousState = previousState,
                TriggeredByUserId = triggeredByUserId,
                OccurredAt = occurredAt == default ? DateTime.UtcNow : occurredAt,
                Source = source,
                CorrelationId = correlationId
            };
        }
    }
}
