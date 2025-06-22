using System;

namespace Boilerplate.Jobs
{
    public class ErrorData
    {
        public static ErrorData FromException(Exception ex)
        {
            return new()
            {
                Type = ex.GetType().FullName,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                InnerError = ex.InnerException != null
                    ? FromException(ex.InnerException)
                    : null
            };
        }

        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public ErrorData InnerError { get; set; }
    }
}