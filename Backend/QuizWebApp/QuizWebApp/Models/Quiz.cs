using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizWebApp.Models;

public class Quiz
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int Id { get; init; }
    public string QuizName { get; set; }
    public Difficulty Difficulty { get; set; }
    public float Popularity { get; set; }
    public float Rating { get; set; }
    public bool IsApproved { get; set; }
    public string? ThumbnailUrl { get; set; }
    [JsonIgnore]
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}