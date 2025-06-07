using System;

namespace AuthenticationService.Exceptions
{
    public class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException() : base() { }
        public InvalidCredentialsException(string message) : base(message) { }
    }
}
