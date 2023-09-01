namespace ShijiMiddlewareTask.User.Providers
{
    public interface IUserProvider
    {
        public Task<int> GetUserNextId(string clientId);
    }
}
