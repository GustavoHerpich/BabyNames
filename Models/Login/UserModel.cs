using BabyName.Models.Enums;

namespace BabyName.Models.Login;

public class UserModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required Roles Role { get; set; }
}