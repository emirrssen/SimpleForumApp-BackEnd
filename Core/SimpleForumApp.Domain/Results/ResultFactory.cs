namespace SimpleForumApp.Domain.Results
{
    public static class ResultFactory
    {
        public static Result SuccessResult(string message) => new(true, message, Enums.ResultCodes.SUCCESS);
        public static Result FailResult(string message) => new(false, message, Enums.ResultCodes.ERROR);
        public static Result SuccessResult() => new(true, Enums.ResultCodes.SUCCESS);
        public static Result FailResult() => new(false, Enums.ResultCodes.ERROR);
        public static ResultWithData<TData> SuccessResult<TData>(string message, TData data) => new(true, message, Enums.ResultCodes.SUCCESS, data);
        public static ResultWithData<TData> FailResult<TData>(string message, TData data) => new(false, message, Enums.ResultCodes.ERROR, data);
        public static ResultWithData<TData> SuccessResult<TData>(string message) => new(true, message, Enums.ResultCodes.SUCCESS);
        public static ResultWithData<TData> FailResult<TData>(string message) => new(false, message, Enums.ResultCodes.ERROR);
        public static ResultWithData<TData> SuccessResult<TData>(TData data) => new(true, Enums.ResultCodes.SUCCESS, data);
        public static ResultWithData<TData> WarningResult<TData>(TData data) => new(false, Enums.ResultCodes.WARNING, data);
        public static ResultWithData<TData> WarningResult<TData>(TData data, string message) => new(false, message, Enums.ResultCodes.WARNING, data);
        public static ResultWithData<TData> WarningResult<TData>(string message) => new(false, message, Enums.ResultCodes.WARNING);
    }
}
