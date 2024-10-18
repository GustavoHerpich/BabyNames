using System.ComponentModel.DataAnnotations;

namespace BabyName.Models.Settings;

public class AppSettings
{
    public const string SectionName = "AppSettings";

    [Required]
    public string? APISecret { get; set; }

    [Required]
    public string? ExpirationToken { get; set; }
}
