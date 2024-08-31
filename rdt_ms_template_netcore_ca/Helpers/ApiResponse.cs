using System.Diagnostics.CodeAnalysis;

namespace rdt_ms_template_netcore_ca.Helpers
{
    /// <summary>
    /// Esta clase es la de respuesta por parte del servicio o controller de manera generica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse()
        {
            Errors = new List<string>();
        }

        [ExcludeFromCodeCoverage]
        public ApiResponse(T data, bool success = true, string message = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = new List<string>();
        }

        [ExcludeFromCodeCoverage]
        public ApiResponse(List<string> errors, bool success = false, string message = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
            Data = default;
        }
    }
}
