using Microsoft.EntityFrameworkCore;
using Moq;
using QuizWebApp.DatabaseServices;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;
using QuizWebAppTest.TestContexts;

namespace QuizWebAppTest;

public class Tests
{
    private static DbContextOptions<WQuizzDBContext> _dbContextOptions;
    private TestWQuizzDBContext _testDbContext;
    private IQuizRepository _quizRepository;
    private IQuestionRepository _questionRepository;
    private IAnswerRepository _answerRepository;
    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptionsBuilder<WQuizzDBContext>().UseInMemoryDatabase(databaseName: "WQuizzDB")
            .Options;
        _testDbContext = new TestWQuizzDBContext();
        _quizRepository = new QuizRepository(_testDbContext);
        _questionRepository = new QuestionRepository(_testDbContext);
        _answerRepository = new AnswerRepository(_testDbContext);
    }

    [Test]
    public void TheQuizzesAreSeedIntoDatabase()
    {
        var seededData = _quizRepository.GetAll();
        Assert.That(seededData.Count(), Is.EqualTo(4));
    }
    
    #region Relation between Quiz and Question entities

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public void GetQuestionsRelatedToQuiz(int quizId)
    {
        var quiz = _quizRepository.GetById(quizId);
        Assert.Multiple(() =>
        {
            foreach (var question in quiz.Questions)
            {
                Assert.That(question.Quiz, Is.EqualTo(quiz));
            }
        });
    }

    [Test]
    [TestCase(1)]
    public void RelatedQuizIncludesQuestionInQuestions(int questionId)
    {
        var question = _questionRepository.GetById(questionId);
        Assert.That(question.Quiz.Questions, Does.Contain(question));
    }
    
    #endregion

    #region Relation between Question and Answer entities

    [Test]
    [TestCase(1)]
    [TestCase(7)]
    public void GetAnswersRelatedToQuestion(int questionId)
    {
        var question = _questionRepository.GetById(questionId);
        Assert.Multiple(() =>
        {
            foreach (var answer in question.Answers)
            {
                Assert.That(answer.Question, Is.EqualTo(question));
            }
        });
    }

    [Test]
    [TestCase(1)]
    [TestCase(8)]
    [TestCase(11)]
    public void RelatedQuizIncludesAnswerInAnswersProperty(int answerId)
    {
        var answer = _answerRepository.GetById(answerId);
        Assert.That(answer.Question.Answers, Does.Contain(answer));
    }
    #endregion
}