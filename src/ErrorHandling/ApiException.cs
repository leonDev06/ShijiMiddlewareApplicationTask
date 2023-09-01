using System.Net;

namespace ShijiMiddlewareTask.ErrorHandling
{
    public class ApiException : Exception
    {
        // The status code of the encountered exception
        private HttpStatusCode _statusCode;

        // StatusCode property is mostly accessed in controller level and is always required to be an int.
        // I've implemented a getter for the statusCode that automatically casts it into an int.
        public int StatusCode {
            get 
            { 
                return (int)_statusCode; // Return StatusCode object as an int
            }
        }

        // Constructor. We use this when throwing new errors.
        public ApiException(HttpStatusCode statusCode, string message): base(message) 
        {
            _statusCode = statusCode;
        }
    }
}
