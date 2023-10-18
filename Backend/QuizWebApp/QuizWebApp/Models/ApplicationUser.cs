using Microsoft.AspNetCore.Identity;

namespace QuizWebApp.Models;

public class ApplicationUser : IdentityUser
{
    public UserProfile? UserProfile { get; set; }
    public int ProfileId { get; set; }
}