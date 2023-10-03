using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers;

[ApiController]
[Route("/api/dummy")]
public class DummyController : ControllerBase
{
    private readonly IQuizRepository _quizRepository;
    public DummyController(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    [HttpGet]
    public IActionResult GetDummy()
    {
        Quiz testQuiz = new Quiz
        {
            QuizName = "DATABASE TEST",
            Difficulty = Difficulty.Hard,
            IsApproved = true,
            Popularity = 3489.123f,
            Rating = 10f,
            ThumbnailUrl = "kiskutya11.com/krisztian"
        };
        _quizRepository.Add(testQuiz);
        return Ok(_quizRepository.GetByName(testQuiz.QuizName).QuizName);
    }
}