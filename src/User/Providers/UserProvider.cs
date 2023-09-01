using ShijiMiddlewareTask.MockDatabase;

namespace ShijiMiddlewareTask.User.Providers
{
    public class UserProvider : IUserProvider
    {
        // Our access to the Mock-Database
        private Database _db;

        // Constructor
        public UserProvider(Database db) 
        {
            _db = db;
        }

        // Provides resource access
        public async Task<int> GetUserNextId(string clientId)
        {
            return await Task.FromResult(_db.GetNextValueById(clientId));
        }
    }
}
