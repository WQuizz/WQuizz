using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizRepository _quizRepository;

    public QuizController(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    [HttpPost("AddQuiz")]
    public IActionResult AddQuiz([Required]string quizName, [Required]string difficulty, string? thumbnailUrl)
    {
        
        var difficultyEnum = Enum.TryParse(difficulty, true, out Difficulty parsed) ? parsed : Difficulty.Easy;
        var postQuiz = new Quiz
        {
            QuizName = quizName,
            Difficulty = difficultyEnum,
            Popularity = 0,
            Rating = 0,
            IsApproved = false,
            ThumbnailUrl = thumbnailUrl
        };
        _quizRepository.Add(postQuiz);
        return Ok("Successfully Added new Quiz");
    }
    [HttpDelete("RemoveQuizById")]
    public IActionResult RemoveQuizById([Required]int id)
    {
        var quizToRemove = _quizRepository.GetById(id);
        if (quizToRemove == null) return NotFound("Quiz by that id doesn't exist");
        _quizRepository.Delete(quizToRemove);
        return Ok("Successfully removed Quiz");
    }

    [HttpGet("GetQuizzesContaining")]
    public ActionResult<IEnumerable<Quiz>?> GetQuizzesContaining([Required]string searchTerm)
    {
        return _quizRepository.GetAll().Where(quiz => quiz.QuizName.ToLower().Contains(searchTerm.ToLower())).ToList();
    }

    [HttpGet("GetRandomApprovedQuiz")]
    public IActionResult GetRandomApprovedQuiz()
    {
        var results = _quizRepository.GetAll().Where(quiz => quiz.IsApproved).ToList();
        return Ok(results[new Random().Next(0, results.Count)]);
    }
}