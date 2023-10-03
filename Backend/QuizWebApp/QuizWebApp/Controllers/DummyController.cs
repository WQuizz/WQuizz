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
        var testGetByName = _quizRepository.GetByName(testQuiz.QuizName);
        return Ok(testGetByName.QuizName + " " + testGetByName.Id);
    }

    [HttpPost("AddQuestion")]
    public IActionResult AddQuestion(int quizId, string questionContent, int? timeLimit, string? questionImgUrl)
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
        _quizRepository.Update(quiz);
        return Ok("Successfully Added question");
    }
    
    [HttpPost("AddAnswer")]
    public IActionResult AddAnswer(int questionId, string answerContent, bool isCorrect)
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
        _questionRepository.Update(question);
        return Ok("Successfully Added answer");
    }

}