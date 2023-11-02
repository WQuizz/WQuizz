using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;
using QuizWebAppTest.TestContexts;

namespace QuizWebAppTest.NonAuthTests;

public class RepositoryTests
{
    private TestWQuizzDBContext _testDbContext;
    private IQuizRepository _quizRepository;
    private IQuestionRepository _questionRepository;
    private IAnswerRepository _answerRepository;
    [SetUp]
    public void Setup()
    {
        _testDbContext = new TestWQuizzDBContext();
        _quizRepository = new QuizRepository(_testDbContext);
        _questionRepository = new QuestionRepository(_testDbContext);
        _answerRepository = new AnswerRepository(_testDbContext);
    }
    [Test]
    public void QuizCRUDTest()
    {
        string newName = "NEW NAME";
        var quiz = _quizRepository.GetById(1);
        quiz.QuizName = newName;
        _quizRepository.Update(quiz);
        var updatedQuiz = _quizRepository.GetById(1);
        Assert.That(updatedQuiz.QuizName, Is.EqualTo(newName));
        var newQuiz = new Quiz
        {
            QuizName = updatedQuiz.QuizName.ToLower(),
            Difficulty = updatedQuiz.Difficulty,
            IsApproved = updatedQuiz.IsApproved,
            Popularity = updatedQuiz.Popularity,
            Rating = updatedQuiz.Rating,
            ThumbnailUrl = updatedQuiz.ThumbnailUrl
        };
        _quizRepository.Add(newQuiz);
        Assert.That(_quizRepository.GetByName(newName.ToLower()), Is.Not.Null);
        _quizRepository.Delete(_quizRepository.GetByName(newName.ToLower()));
        Assert.That(_quizRepository.GetByName(newName.ToLower()), Is.Null);
    }

    [Test]
    public void QuestionCRUDTest()
    {
        string newContent = "NEW CONTENT";
        var question = _questionRepository.GetById(1);
        question.QuestionContent = newContent;
        _questionRepository.Update(question);
        Assert.That(_questionRepository.GetById(1).QuestionContent, Is.EqualTo(newContent));
        string newQuestionContent = "THIS QUESTION WAS NEWLY CREATED";
        var newQuestion = new Question
        {
            QuestionContent = newQuestionContent,
            QuizId = question.QuizId
        };
        _questionRepository.Add(newQuestion);
        Assert.That(_questionRepository.GetAll().Last().QuestionContent, Is.EqualTo(newQuestionContent));
        _questionRepository.Delete(newQuestion);
        Assert.That(_questionRepository.GetAll().Last().QuestionContent, Is.Not.EqualTo(newQuestionContent));
    }
    [Test]
    public void AnswerCRUDTest()
    {
        string newContent = "NEW CONTENT";
        var answer = _answerRepository.GetById(1);
        answer.AnswerContent = newContent;
        _answerRepository.Update(answer);
        Assert.That(_answerRepository.GetById(1).AnswerContent, Is.EqualTo(newContent));
        string newAnswerContent = "THIS ANSWER WAS NEWLY CREATED";
        var newAnswer = new Answer
        {
            AnswerContent = newAnswerContent,
            IsCorrect = false,
            QuestionId = answer.QuestionId
        };
        _answerRepository.Add(newAnswer);
        Assert.That(_answerRepository.GetAll().Last().AnswerContent, Is.EqualTo(newAnswerContent));
        _answerRepository.Delete(newAnswer);
        Assert.That(_answerRepository.GetAll().Last().AnswerContent, Is.Not.EqualTo(newAnswerContent));
    }
}