using Bidding.API.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;

namespace Bidding.API.Services.JwtService
{
    public interface IJwtService
    {
        AuthenticationResponse CreateToken(IdentityUser user);
    }
}
