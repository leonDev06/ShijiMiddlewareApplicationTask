namespace ShijiMiddlewareTask.MockDatabase
{
    public class Database
    {
        // This is a mock database that's provided in-memory. This class is instantiated as a singleton.
        // This is supposed to hold our data structures which will act as our Database for this app.

        // Database properties
        public Dictionary<string, int> UsersData;       // Our Data Structure resource.
        private readonly object _lock = new object();   // The lock for our resource. Ensures only 1 thread at a time can modify our data.

        // Constructor
        public Database() 
        { 
            // Instantiate our Dictionary first-time upon server-boot.
            UsersData = new Dictionary<string, int>();
        }

        public int GetNextValueById(string clientId)
        {
            clientId = clientId.ToUpper();
            lock (_lock)    // Allow 1 thread at a time. Concurrent requests must wait.
            {
                // Catch newly-inserted clientIds
                if(!UsersData.ContainsKey(clientId)) return UsersData[clientId] = 1;

                // Base-case to return is we increment the value of key clientId
                return ++UsersData[clientId];
            }
        }
    }
}
