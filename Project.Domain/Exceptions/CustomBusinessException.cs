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
    public class ForbiddenExeption : Exception
    {
        public ForbiddenExeption(string message) : base(message) 
        {
        }
    }
}
