using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizWebApp.DatabaseServices;
using QuizWebApp.Models;

namespace QuizWebApp.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly WQuizzDBContext _dbContext;

    public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService, WQuizzDBContext dbContext)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _dbContext = dbContext;
    }

    public async Task<AuthResult> RegisterAsync(string email, string username, string password, string role)
    {
        var user = new ApplicationUser { UserName = username, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return FailedRegistration(result, email, username);
        
        var userProfile = new UserProfile
        {
            UserId = user.Id,
            DisplayName = username,
            ProfilePicture = null
            // You can set ProfilePicture to null or a default value if needed
        };
        
        _dbContext.UserProfiles.Add(userProfile);
        await _dbContext.SaveChangesAsync();

        user.UserProfile = userProfile;
        user.ProfileId = userProfile.Id;
        
        await _userManager.AddToRoleAsync(user, role);
        return new AuthResult(true, email, username, "");

    }

    public async Task<AuthResult> LoginAsync(string email, string password)
    {
        var managedUser = await _userManager.FindByEmailAsync(email);

        if (managedUser == null)
            return InvalidEmail(email);

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);

        if (!isPasswordValid)
            return InvalidPassword(email, managedUser.UserName);

        var roles = await _userManager.GetRolesAsync(managedUser);
        var accessToken = _tokenService.CreateToken(managedUser, roles[0]);

        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }


    private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
    {
        var authResult = new AuthResult(false, email, username, "");

        foreach (var error in result.Errors) authResult.ErrorMessages.Add(error.Code, error.Description);

        return authResult;
    }


    private static AuthResult InvalidEmail(string email)
    {
        var result = new AuthResult(false, email, "", "");
        result.ErrorMessages.Add("Bad credentials", "Invalid email");
        return result;
    }

    private static AuthResult InvalidPassword(string email, string userName)
    {
        var result = new AuthResult(false, email, userName, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid password");
        return result;
    }
}