using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizWebApp.Models;

public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int Id { get; init; }
    [JsonIgnore]
    public int QuizId { get; init; }
    [JsonIgnore]
    public Quiz Quiz { get; init; }
    public string QuestionContent { get; set; }
    public string? QuestionImgUrl { get; set; }
    public int? TimeLimit { get; set; }
    [JsonIgnore]
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}