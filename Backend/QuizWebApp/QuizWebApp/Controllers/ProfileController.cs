using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using QuizWebApp.DatabaseServices;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers;


[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly WQuizzDBContext _dbContext;
    public ProfileController(UserManager<ApplicationUser> userManager, WQuizzDBContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    [HttpPost("UpdateProfile")]
    public async Task<ActionResult>  UpdateProfile()
    {
        var userName = Request.Form["userName"];
        string newDisplayName = Request.Form["displayName"];
        var file = Request.Form.Files["file"];
    
        if (string.IsNullOrWhiteSpace(userName) || file == null)
        {
            return BadRequest("Invalid request data.");
        }
        
        if (!ModelState.IsValid) {return BadRequest(ModelState);}
        
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return BadRequest("User not found.");
        }
        
        var userProfile = await _dbContext.UserProfiles.FindAsync(user.ProfileId);

        if (userProfile == null)
        {
            return BadRequest("User profile not found.");
        }
        
        if (file.Length != 0)
        {
            byte[] profilePictureBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                profilePictureBytes = memoryStream.ToArray();
            }
            if (profilePictureBytes.Length == 0)
            {
                return BadRequest("Couldn't upload picture.");
            }
            userProfile.ProfilePicture = profilePictureBytes;
        }

        if (newDisplayName != null && newDisplayName.Length>3)
        {
            userProfile.DisplayName = newDisplayName;
        }
        
        _dbContext.UserProfiles.Update(userProfile);
        await _dbContext.SaveChangesAsync();
        
        return Ok("Profile picture uploaded and user's profile updated.");
    }
    
    [HttpGet("GetProfile")]
    public async Task<ActionResult<UserProfile>> GetProfile([Required] string userName)
    {
        Console.WriteLine("GetProfile");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return BadRequest("User not found.");
        }
        var userProfile = await _dbContext.UserProfiles.FindAsync(user.ProfileId);
        if (userProfile == null)
        {
            return BadRequest("User profile not found.");
        }

        return Ok(userProfile);
    }
}