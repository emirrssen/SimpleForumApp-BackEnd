using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Results
{
    public static class ResultFactory
    {
        public static Result SuccessResult(string message) => new(true, message);
        public static Result FailResult(string message) => new(false, message);
        public static ResultWithData<TData> SuccessResult<TData>(TData data, string message) => new(true, message, data);
        public static ResultWithData<TData> FailResult<TData>(TData data, string message) => new(false, message, data);
        public static ResultWithData<TData> SuccessResult<TData>(string message) => new(true, message);
        public static ResultWithData<TData> FailResult<TData>(string message) => new(false, message);
    }
}
