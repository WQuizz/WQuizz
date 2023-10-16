using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
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
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;

    public DummyController(IQuizRepository quizRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
    {
        _quizRepository = quizRepository;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
    }

    [HttpGet, Authorize(Roles = "User, Admin")]
    public IActionResult GetDummy()
    {
        

        Quiz? testGetByName = _quizRepository.GetById(1);
        if (testGetByName == null)
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
        }
        return Ok(testGetByName.QuizName + " " + testGetByName.Id);
    }
}