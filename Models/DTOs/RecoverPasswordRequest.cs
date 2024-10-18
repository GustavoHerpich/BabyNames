namespace BabyName.Models.DTOs;

public class RecoverPasswordRequest
{
    public required string UserName { get; set; }
    public required string NewPassword { get; set; }
}

