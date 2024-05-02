
namespace Talabat.Api.Errors
{
    public class ApiResponse
    {

        public ApiResponse(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int? statusCode)
        {
            //in C# 7 
            return statusCode switch
            {
                500=> "Internal Server Error",
                400=>  "Bad Request",
                401 =>"Unauthorized",
                404=>"Not Found",
                _ =>null

            };
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
