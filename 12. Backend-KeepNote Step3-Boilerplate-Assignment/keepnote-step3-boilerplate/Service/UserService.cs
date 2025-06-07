using DAL;
using Entities;
using Exceptions;
using System;

namespace Service
{
    /*
  * Service classes are used here to implement additional business logic/validation
  * */
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        /*
       Use constructor Injection to inject all required dependencies.
       */
        public UserService(IUserRepository repository)
        {
            _userRepository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }
        //This method should be used to delete an existing user. 
        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }

        //This method should be used to get a user by userId.
        public User GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            return user ?? throw new UserNotFoundException($"User with id: {userId} does not exist");
        }

        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if(_userRepository.GetUserById(user.UserId) != null)
            {
                throw new UserAlreadyExistException($"This userid: {user.UserId} already exists");
            }

            return _userRepository.RegisterUser(user);
        }

        //This method should be used to update an existing user.
        public bool UpdateUser(int userId, User user)
        {
            if(user == null)
            {
                throw new UserNotFoundException(nameof(user));
            }

            _ = _userRepository.GetUserById(userId) ?? throw new UserNotFoundException($"User with id: {userId} does not exist");

            return _userRepository.UpdateUser(user);
        }

        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(int userId, string password)
        {
            if (_userRepository.ValidateUser(userId, password))
            {
                return true;
            }
            return false;
        }
    }
}
