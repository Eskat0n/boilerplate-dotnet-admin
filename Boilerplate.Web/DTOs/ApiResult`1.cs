using System.Text.Json.Serialization;

namespace Boilerplate.Web.DTOs
{
    public class ApiResult<T>
        where T : class
    {
        [JsonPropertyName("success")]
        public bool IsSuccess { get; set; }

        public string? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }

        public T? Data { get; set; }
    }
}
