using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWebApp.Models;

public class Answer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public int QuestionId { get; init; }
    public Question Question { get; init; }
    public string AnswerContent { get; set; }
    public bool IsCorrect { get; set; }
}