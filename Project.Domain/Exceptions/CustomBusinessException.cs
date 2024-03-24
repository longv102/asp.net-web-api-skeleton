namespace Project.Domain.Exceptions
{
    /// <summary>
    /// Business exception, can be customized depending on requirements
    /// </summary>
    public class CustomBusinessException : Exception
    {
        public CustomBusinessException(string message) : base(message)
        {
        }
    }
    /// <summary>
    /// Example
    /// </summary>
    public class ForbiddenAccessExeption : Exception
    {
        public ForbiddenAccessExeption(string message) : base(message) 
        {
        }
    }
}
