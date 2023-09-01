namespace ShijiMiddlewareTask.User.Services
{
    public interface IUserService
    {
        public Task<int> GetNextId(string clientId);
    }
}
