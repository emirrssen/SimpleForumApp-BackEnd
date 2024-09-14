using SimpleForumApp.Domain.Enums;

namespace SimpleForumApp.Domain.Results
{
    public class ResultWithData<TData> : Result
    {
        public ResultWithData(bool isSuccess, string message, ResultCodes code, TData data) : base(isSuccess, message, code)
        {
            Data = data;
        }

        public ResultWithData(bool isSuccess, ResultCodes code, TData data) : base(isSuccess, code)
        {
            Data = data;
        }

        public ResultWithData(bool isSuccess, string message, ResultCodes code) : base(isSuccess, message, code) { }

        public TData? Data { get; set; }
    }
}
