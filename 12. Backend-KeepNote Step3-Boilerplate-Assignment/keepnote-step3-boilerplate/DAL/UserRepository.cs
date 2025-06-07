using System;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class UserRepository : IUserRepository
    {
        private readonly KeepDbContext _dbContext;
        public UserRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //This method should be used to delete an existing user. 
        public bool DeleteUser(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        //This method should be used to get a user by userId.
        public User GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(c => c.UserId == userId);
        }

        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return true;
        }
        //This method should be used to update an existing user.
        public bool UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(c => c.UserId == user.UserId);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            existingUser.Contact = user.Contact;
            existingUser.CreatedAt = user.CreatedAt;

            _dbContext.Entry(existingUser).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(int userId, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);

            if(user.Password != password)
            {
                return false;
            }
            return true;
        }
    }
}
