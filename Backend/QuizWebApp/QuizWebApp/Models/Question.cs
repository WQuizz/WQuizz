using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWebApp.Models;

public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public int QuizId { get; init; }
    public Quiz Quiz { get; init; }
    public string QuestionContent { get; set; }
    public string? QuestionImgUrl { get; set; }
    public int? TimeLimit { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}