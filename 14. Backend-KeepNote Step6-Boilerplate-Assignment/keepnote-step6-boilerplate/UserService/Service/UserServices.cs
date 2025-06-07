using System;
using UserService.Exceptions;
using UserService.Models;
using UserService.Repository;

namespace UserService.Service
{
    public class UserServices : IUserService
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public bool DeleteUser(string userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
                throw new UserNotFoundException($"User with ID {userId} not found");

            return _userRepository.DeleteUser(userId);
        }
        
        public User GetUserById(string userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
                throw new UserNotCreatedException($"User with ID {userId} not found");

            return user;
        }
        
        public User RegisterUser(User user)
        {
            if(user == null)
                throw new ArgumentNullException("user");
            return _userRepository.RegisterUser(user);
        }
        
        public bool UpdateUser(string userId, User user)
        {
            if (user == null)
                throw new ArgumentException("Category cannot be null");

            var existingCategory = _userRepository.GetUserById(userId);
            if (existingCategory == null)
                throw new UserNotFoundException($"User with ID {userId} not found");

            return _userRepository.UpdateUser(userId, user);
        }
    }
}
