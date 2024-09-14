using SimpleForumApp.Domain.Enums;

namespace SimpleForumApp.Domain.Results
{
    public class Result
    {
        public Result(bool isSuccess, string message, ResultCodes code)
        {
            IsSuccess = isSuccess;
            Message = message;
            Code = code;
        }

        public Result(bool isSuccess, ResultCodes code)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ResultCodes Code { get; set; }
    }
}
