using System.ComponentModel.DataAnnotations;

namespace Bidding.API.Models.RequestModels;

public class AuthenticationRequest
{
    public required string UserName { get; set; } 
    public required string Password { get; set; }
}

