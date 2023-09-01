using ShijiMiddlewareTask.ErrorHandling;
using ShijiMiddlewareTask.User.Providers;
using System.Net;

namespace ShijiMiddlewareTask.User.Services
{
    public class UserService : IUserService
    {
        // Here in the service level is where I'll filter out the request. This is also where I throw corresponding errors.

        // Service properties
        private readonly IUserProvider _userProvider;

        // Constructor
        public UserService(IUserProvider provider) 
        {
            _userProvider = provider;
        }

        // Service methods
        public Task<int> GetNextId(string clientId)
        {
            // Example filtering of request. ClientId must not be less than 3 characters.
            if(clientId.Length < 3)
            {
                throw new ApiException(HttpStatusCode.BadRequest, "ClientId must contain at least 3 characters");
            }

            // Example error. ClientId must not be equal to 'THISISANINVALIDCLIENTID'.
            var invalidClientId = "THISISANINVALIDCLIENTID";
            if (clientId.ToUpper().Equals(invalidClientId))
            {
                throw new ApiException(HttpStatusCode.BadRequest, $"'{invalidClientId}' is not a valid clientId");
            }

            // If the user request passed the filtering, we access the repository/provider level.
            return this._userProvider.GetUserNextId(clientId);
        }
    }
}
