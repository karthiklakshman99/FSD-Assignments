using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using System;
using System.Security.Authentication;

namespace AuthenticationService.Service
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public bool RegisterUser(User user)
        {
            if (_authRepository.IsUserExists(user.UserId))
            {
                throw new UserAlreadyExistsException("User with the given UserId already exists.");
            }

            return _authRepository.CreateUser(user);
        }

        public bool LoginUser(User user)
        {
            if (!_authRepository.LoginUser(user))
            {
                throw new InvalidCredentialsException("Invalid UserId or Password.");
            }

            return true;
        }
    }
}
