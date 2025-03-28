namespace XenoTerra.WebAPI.Services.Mutations.Base
{
    public class OperationResult<T>
        where T : class
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
        public T? Result { get; init; }
        public IReadOnlyList<string>? Errors { get; init; }

        public static OperationResult<T> FromSuccess(string message) =>
            new() { Success = true, Message = message };

        public static OperationResult<T> FromSuccess(string message, T result) =>
            new() { Success = true, Message = message, Result = result };

        public static OperationResult<T> FromFailure(string message, IReadOnlyList<string> errors) =>
            new() { Success = false, Message = message, Errors = errors };
    }
}
