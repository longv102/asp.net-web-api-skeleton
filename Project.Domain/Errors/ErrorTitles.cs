namespace Project.Domain.Errors
{
    /// <summary>
    /// Error titles
    /// </summary>
    public class ErrorTitles
    {
        /// <summary>
        /// An unexpected error has occured in application!
        /// </summary>
        public static readonly string InternalServerError = "An unexpected error has occured in application!";

        public static readonly string NotSupportedError = "The feature is not supported at the moment!";
        /// <summary>
        /// The target object is not found!
        /// </summary>
        public static readonly string NotFound = "The target object is not found!";

        public static readonly string UnauthorizedAccess = "The resource is limited for some user roles!";
    }
}
