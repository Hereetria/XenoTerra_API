namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Events
{
    public abstract record UpdatedEvent<TResult> : BaseEvent<TResult> where TResult : class
    {
        public IEnumerable<string> ModifiedFields { get; init; } = [];

        public static TEvent From<TEvent>(
            TResult result,
            Guid triggeredByUserId,
            DateTime occurredAt,
            IEnumerable<string> modifiedFields,
            string? source = null,
            string? correlationId = null)
            where TEvent : UpdatedEvent<TResult>, new()
        {
            return new TEvent
            {
                Result = result,
                TriggeredByUserId = triggeredByUserId,
                OccurredAt = occurredAt,
                ModifiedFields = modifiedFields,
                Source = source,
                CorrelationId = correlationId,
            };
        }
    }
}
