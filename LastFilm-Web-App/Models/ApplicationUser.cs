using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Models;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Full name ")]
    public string FullName { get; set; }
}
