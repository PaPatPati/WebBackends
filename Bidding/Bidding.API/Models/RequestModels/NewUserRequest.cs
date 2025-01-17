namespace Bidding.API.Models.RequestModels;

public class NewUserRequest
{
    public required string UserName { get; set; } 
    public required string Email { get; set; } 
    public required string Password { get; set; } 
}
