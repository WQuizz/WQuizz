using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuizRepository _quizRepository;

    public QuestionController(IQuestionRepository questionRepository, IQuizRepository quizRepository)
    {
        _questionRepository = questionRepository;
        _quizRepository = quizRepository;
    }
    [HttpPost("AddQuestion")]
    public IActionResult AddQuestion([Required]int quizId, [Required]string questionContent, int? timeLimit, string? questionImgUrl)
    {
        var quiz = _quizRepository.GetById(quizId);
        if (quiz == null) return Ok("Quiz by that id doesn't exist");
        var postQuestion = new Question
        {
            QuizId = quizId,
            QuestionContent = questionContent,
            Quiz = quiz,
            TimeLimit = timeLimit,
            QuestionImgUrl = questionImgUrl
        };
        _questionRepository.Add(postQuestion);
        //Updating quiz
        quiz.Questions.Add(postQuestion);
        return Ok("Successfully Added question");
    }
    
    [HttpDelete("RemoveQuestionById")]
    public IActionResult RemoveQuestionById([Required]int id)
    {
        var questionToRemove = _questionRepository.GetById(id);
        if (questionToRemove == null) return Ok("Question by that id doesn't exist");
        _questionRepository.Delete(questionToRemove);
        return Ok("Successfully removed question");
    }
}