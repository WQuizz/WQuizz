using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuestionRepository _questionRepository;

    public AnswerController(IAnswerRepository answerRepository, IQuestionRepository questionRepository)
    {
        _answerRepository = answerRepository;
        _questionRepository = questionRepository;
    }

    [HttpPost("AddAnswer")]
    public IActionResult AddAnswer([Required]int questionId, [Required]string answerContent, [Required]bool isCorrect)
    {
        var question = _questionRepository.GetById(questionId);
        if (question == null) return Ok("Question by that id doesn't exist");
        var postAnswer = new Answer
        {
            Question = question,
            AnswerContent = answerContent,
            IsCorrect = isCorrect
        };
        _answerRepository.Add(postAnswer);
        //Updating question
        question.Answers.Add(postAnswer);
        return Ok("Successfully Added answer");
    }

    [HttpPost("AddMultipleAnswers")]
    public IActionResult AddAnswers([Required]int questionId, [Required]Tuple<string, bool>[] answers)
    {
        var question = _questionRepository.GetById(questionId);
        if (question == null) return Ok("Question by that id doesn't exist");
        foreach (var answer in answers)
        {
            var postAnswer = new Answer
            {
                Question = question,
                AnswerContent = answer.Item1,
                IsCorrect = answer.Item2
            };
            _answerRepository.Add(postAnswer);
            //Updating question
            question.Answers.Add(postAnswer);
        }
        return Ok("Successfully Added answers");
    }

    [HttpDelete("RemoveAnswerById")]
    public IActionResult RemoveAnswerById([Required]int id)
    {
        var answerToRemove = _answerRepository.GetById(id);
        if (answerToRemove == null) return Ok("Answer by that id doesn't exist");
        _answerRepository.Delete(answerToRemove);
        return Ok("Successfully removed answer");
    }
}