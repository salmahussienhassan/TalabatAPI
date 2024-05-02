namespace Talabat.Api.Errors
{
    public class ValidationErrorResponse:ApiResponse
    {
        public ValidationErrorResponse():base(400)
        {
            Errors=new List<string>();
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
