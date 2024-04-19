namespace SimpleForumApp.Domain.Results
{
    public static class ResultFactory
    {
        public static Result SuccessResult(string message) => new(true, message);
        public static Result FailResult(string message) => new(false, message);
        public static Result SuccessResult() => new(true);
        public static Result FailResult() => new(false);
        public static ResultWithData<TData> SuccessResult<TData>(string message, TData data) => new(true, message, data);
        public static ResultWithData<TData> FailResult<TData>(string message, TData data) => new(false, message, data);
        public static ResultWithData<TData> SuccessResult<TData>(string message) => new(true, message);
        public static ResultWithData<TData> FailResult<TData>(string message) => new(false, message);
        public static ResultWithData<TData> SuccessResult<TData>(TData data) => new(true, data);
    }
}
