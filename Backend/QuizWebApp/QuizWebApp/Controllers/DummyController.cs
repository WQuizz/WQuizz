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
    //Quiz related Http requests
    [HttpPost("AddQuiz")]
    public IActionResult AddQuiz(string quizName, string difficulty, string? thumbnailUrl)
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
    public IActionResult RemoveQuizById(int id)
    {
        var quizToRemove = _quizRepository.GetById(id);
        if (quizToRemove == null) return Ok("Quiz by that id doesn't exist");
        _quizRepository.Delete(quizToRemove);
        return Ok("Successfully removed Quiz");
    }
    
    //Question related Http requests
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
        return Ok("Successfully Added question");
    }
    
    [HttpDelete("RemoveQuestionById")]
    public IActionResult RemoveQuestionById(int id)
    {
        var questionToRemove = _questionRepository.GetById(id);
        if (questionToRemove == null) return Ok("Question by that id doesn't exist");
        _questionRepository.Delete(questionToRemove);
        return Ok("Successfully removed question");
    }

    
    //Answer related Http requests
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
        return Ok("Successfully Added answer");
    }

    [HttpPost("AddMultipleAnswers")]
    public IActionResult AddAnswers(int questionId, Tuple<string, bool>[] answers)
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
    public IActionResult RemoveAnswerById(int id)
    {
        var answerToRemove = _answerRepository.GetById(id);
        if (answerToRemove == null) return Ok("Answer by that id doesn't exist");
        _answerRepository.Delete(answerToRemove);
        return Ok("Successfully removed answer");
    }
}