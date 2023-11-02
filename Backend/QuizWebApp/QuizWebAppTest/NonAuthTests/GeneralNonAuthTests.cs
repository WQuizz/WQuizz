using QuizWebApp.DatabaseServices.Repositories;
using QuizWebAppTest.TestContexts;

namespace QuizWebAppTest.NonAuthTests;

public class GeneralNonAuthTests
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
    public void DatabaseIsSeeded()
    {
        var allQuizzes = _quizRepository.GetAll();
        var allQuestions = _questionRepository.GetAll();
        var allAnswers = _answerRepository.GetAll();
        Assert.Multiple(() =>
        {
            Assert.Positive(allQuizzes.Count());
            Assert.Positive(allQuestions.Count());
            Assert.Positive(allAnswers.Count());
        });
    }
    [Test]
    public void AllQuestionsHaveAtLeastOneCorrectAnswers()
    {
        var allQuestions = _questionRepository.GetAll();
        Assert.Multiple(() =>
        {
            foreach (var question in allQuestions)
            {
                Assert.That(question.Answers.Any(ans => ans.IsCorrect), Is.True);
            }
        });
    }
}