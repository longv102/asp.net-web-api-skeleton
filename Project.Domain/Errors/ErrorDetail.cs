namespace Project.Domain.Errors
{
    public class ErrorDetail
    {
        public string? Title { get; set; }

        public int StatusCode { get; set; }

        public required string Message { get; set; }
    }
}
