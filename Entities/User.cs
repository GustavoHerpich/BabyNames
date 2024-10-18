﻿using BabyName.Models.Enums;

namespace BabyName.Entities;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public DateTime PasswordExpiration { get; set; }
    public required Roles Role { get; set; }
}

