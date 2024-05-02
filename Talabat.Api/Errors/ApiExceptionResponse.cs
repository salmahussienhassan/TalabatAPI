namespace Talabat.Api.Errors
{
    public class ApiExceptionResponse:ApiResponse
    {
        public ApiExceptionResponse(int Statuscode,string? message=null,string? details = null):base(Statuscode)
        {
            Details = details;
        }
        public string? Details { get; set; }
    }
}
