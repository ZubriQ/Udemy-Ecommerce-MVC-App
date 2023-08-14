using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Data.ViewModels;

public class LoginVM
{
    [Display(Name = "Email address")]
    [Required(ErrorMessage = "Email address is required")]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
