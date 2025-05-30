namespace Passwords.Models;

using System.ComponentModel.DataAnnotations;

public class PasswordGenerator
{
    [Range(4, 128)]
    public int Length { get; set; } = 12;

    public bool IncludeUppercase { get; set; } = true;
    public bool IncludeLowercase { get; set; } = true;
    public bool IncludeNumbers { get; set; } = true;
    public bool IncludeSymbols { get; set; } = true;

    public string? GeneratedPassword { get; set; }
}
