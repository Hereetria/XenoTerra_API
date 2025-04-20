using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Types.PayloadTypes
{
    public abstract record Payload<TResult> where TResult : class
    {
        public bool Success { get; init; }
        public string Message { get; init; } = "";
        public IReadOnlyList<string> Errors { get; init; } = [];
        public TResult? Result { get; init; }

        public bool HasError() => Errors.Count > 0;

        public static TPayload FromSuccess<TPayload>(string message, TResult? result = null)
            where TPayload : Payload<TResult>, new()
            => new()
            {
                Success = true,
                Message = message,
                Errors = [],
                Result = result
            };

        public static TPayload FromFailure<TPayload>(string message, IReadOnlyList<string> errors)
            where TPayload : Payload<TResult>, new()
            => new()
            {
                Success = false,
                Message = message,
                Errors = errors,
                Result = null
            };
    }
}
