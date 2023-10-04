using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizWebApp.Models;

public class Answer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int Id { get; init; }
    [JsonIgnore]
    public int QuestionId { get; init; }
    [JsonIgnore]
    public Question Question { get; init; }
    public string AnswerContent { get; set; }
    public bool IsCorrect { get; set; }
}