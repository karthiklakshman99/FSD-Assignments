using System;
using System.Linq;
using AuthenticationService.Models;

namespace AuthenticationService.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _dbContext;

        public AuthRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateUser(User user)
        {
            if (_dbContext.Users.Any(u => u.UserId == user.UserId))
            {
                return false;
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool IsUserExists(string userId)
        {
            return _dbContext.Users.Any(u => u.UserId == userId);
        }

        public bool LoginUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);

            if (existingUser == null)
            {
                return false;
            }

            if (existingUser.Password == user.Password)
            {
                return true;
            }

            return false;
        }
    }
}
