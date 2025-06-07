using System;
using System.Linq;
using MongoDB.Driver;
using UserService.Models;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        
        public bool DeleteUser(string userId)
        {
            var result = _context.Users.DeleteOne(c => c.UserId == userId);
            return result.DeletedCount > 0;
        }

        
        public User GetUserById(string userId)
        {
            return _context.Users.Find(c => c.UserId == userId).FirstOrDefault();
        }
        
        public User RegisterUser(User user)
        {
            _context.Users.InsertOne(user);
            return user;
        }
        
        public bool UpdateUser(string userId, User user)
        {
            var result = _context.Users.ReplaceOne(
                c => c.UserId == userId,
                user
            );
            return result.ModifiedCount > 0;
        }
    }
}
