using System.ComponentModel.DataAnnotations;

namespace BlazorJwtAuth.Client.Models;

public class RegistrationModel
{
    [Required]
    public string Name { get; set; }

    [Required, MinLength(3, ErrorMessage = "Password should be at least 3 characters long")]
    public string Password { get; set; }

    [Required, Compare(nameof(Password), ErrorMessage = "Fields Password and Confirm must be the same")]
    public string PasswordConfirmation { get; set; }

    public bool IsEditor { get; set; }
    public bool IsAdmin { get; set; }
}
