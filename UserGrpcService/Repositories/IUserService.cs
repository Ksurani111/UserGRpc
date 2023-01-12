using UserGrpcService.Entities;

namespace UserGrpcService.Repositories
{
    public interface IUserService
    {
        public Task<List<UserDetails>> GetUserListAsync();
        public Task<UserDetails> GetUserByIdAsync(Guid Id);
        public Task<UserDetails> AddUserAsync(UserDetails userDetails);
        public Task<UserDetails> UpdateUserAsync(UserDetails userDetails);
        public Task<bool> DeleteUserAsync(Guid Id);
    }
}
