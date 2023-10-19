using System.Text.Json.Serialization;

namespace QuizWebApp.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string UserId { get; set; } 
    public string UserName { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public string DisplayName { get; set; }
    [JsonIgnore]
    public ApplicationUser User { get; set; }
}