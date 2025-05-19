namespace XenoTerra.WebAPI.GraphQL.Types.EventTypes
{

    public abstract record ChangedEvent<TResult> : BaseEvent<TResult> where TResult : class
    {
        public ChangedEventType ChangedEventType { get; init; }
        public IEnumerable<string>? ModifiedFields { get; init; }

        public static TEvent From<TEvent>(
            ChangedEventType changedEventType,
            TResult result,
            Guid triggeredByUserId,
            DateTime occurredAt,
            IEnumerable<string>? modifiedFields = null,
            string? source = null,
            string? correlationId = null)
            where TEvent : ChangedEvent<TResult>, new()
        {
            return new TEvent
            {
                ChangedEventType = changedEventType,
                Result = result,
                TriggeredByUserId = triggeredByUserId,
                OccurredAt = occurredAt,
                ModifiedFields = modifiedFields,
                Source = source,
                CorrelationId = correlationId
            };
        }
    }
}
