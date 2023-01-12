using Microsoft.EntityFrameworkCore;
using System;
using UserGrpcService.Data;
using UserGrpcService.Entities;

namespace UserGrpcService.Repositories
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _dbContext;

        public UserService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetails> AddUserAsync(UserDetails userDetails)
        {
            userDetails.Id = Guid.NewGuid();
            var result = _dbContext.UserDetails.Add(userDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            var filteredData = _dbContext.UserDetails.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<UserDetails> GetUserByIdAsync(Guid Id)
        {
            return await _dbContext.UserDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<UserDetails>> GetUserListAsync()
        {
            try { 
            return await _dbContext.UserDetails.ToListAsync();
            }
            catch(Exception e)
            { 
            throw;    
            }
        }

        public async Task<UserDetails> UpdateUserAsync(UserDetails userDetails)
        {

            var result = _dbContext.UserDetails.Update(userDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
