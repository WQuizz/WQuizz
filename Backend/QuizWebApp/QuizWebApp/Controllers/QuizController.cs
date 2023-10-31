using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
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
    [HttpPost("AddQuiz"), Authorize(Roles="Admin")]
    public IActionResult AddQuiz([Required]string quizName, [Required]string difficulty,[Required]string category, string? thumbnailUrl)
    {
        
        var difficultyEnum = Enum.TryParse(difficulty, true, out Difficulty parsed) ? parsed : Difficulty.Easy;
        var categoryEnum = Enum.TryParse(category, true, out Category parsed2) ? parsed2 : Category.Entertainment;
        var postQuiz = new Quiz
        {
            QuizName = quizName,
            Difficulty = difficultyEnum,
            CategoryType = categoryEnum,
            Popularity = 0,
            Rating = 0,
            IsApproved = false,
            ThumbnailUrl = thumbnailUrl
        };
        _quizRepository.Add(postQuiz);
        return Ok("Successfully Added new Quiz");
    }
    [HttpDelete("RemoveQuizById"), Authorize(Roles="Admin")]
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

    [HttpGet("GetQuizById")]
    public IActionResult GetQuizById([Required] int id)
    {
        return Ok(_quizRepository.GetById(id));
    }

    [HttpGet("GetQuizByName")]
    public IActionResult GetQuizByName([Required] string name)
    {
        return Ok(_quizRepository.GetByName(name));
    }
}