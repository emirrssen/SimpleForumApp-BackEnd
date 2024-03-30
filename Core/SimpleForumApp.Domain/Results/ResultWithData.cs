using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Results
{
    public class ResultWithData<TData> : Result
    {
        public ResultWithData(bool isSuccess, string message, TData data) : base(isSuccess, message)
        {
            Data = data;
        }

        public ResultWithData(bool isSuccess, string message) : base(isSuccess, message) { }

        public TData? Data { get; set; }
    }
}
