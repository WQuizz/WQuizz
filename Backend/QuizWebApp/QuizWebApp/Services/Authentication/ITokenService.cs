using Microsoft.AspNetCore.Identity;
using QuizWebApp.Models;

namespace QuizWebApp.Services.Authentication;

public interface ITokenService
{
    public string CreateToken(ApplicationUser user, string role);
}