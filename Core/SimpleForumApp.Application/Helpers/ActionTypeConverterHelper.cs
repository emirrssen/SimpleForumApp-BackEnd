using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.Domain.Enums;

namespace SimpleForumApp.Application.Helpers
{
    public class ActionTypeConverterHelper
    {
        public static long ConvertActionType(string type)
        {
            if (type == "GET")
                return (long)ActionTypes.GET;

            if (type == "POST")
                return (long)ActionTypes.POST;

            if (type == "PUT")
                return (long)ActionTypes.PUT;

            if (type == "DELETE")
                return (long)ActionTypes.DELETE;

            return 0;
        }
    }
}
