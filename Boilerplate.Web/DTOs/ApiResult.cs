using System;

namespace Boilerplate.Web.DTOs
{
    public class ApiResult : ApiResult<object>
    {
        public static ApiResult Success() =>
            new ApiResult {IsSuccess = true};

        public static ApiResult<T> Success<T>(T data)
            where T : class =>
            new ApiResult<T> {IsSuccess = true, Data = data};

        public static ApiResult Failure(string message) =>
            new ApiResult {IsSuccess = false, ErrorMessage = message};

        public static ApiResult Failure(Exception exception) =>
            new ApiResult {IsSuccess = false, ErrorType = exception.GetType().FullName, ErrorMessage = exception.Message};
    }
}
