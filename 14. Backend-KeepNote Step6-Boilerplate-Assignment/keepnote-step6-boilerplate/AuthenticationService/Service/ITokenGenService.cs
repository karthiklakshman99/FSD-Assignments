using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace AuthenticationService.Service
{
    public interface ITokenGenService
    {
        string GenerateJwtToken(string userId);

    }
}
