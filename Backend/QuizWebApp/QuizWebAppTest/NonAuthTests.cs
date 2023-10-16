using Microsoft.EntityFrameworkCore;
using Moq;
using QuizWebApp.DatabaseServices;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebAppTest.TestContexts;

namespace QuizWebAppTest;

public class Tests
{
    private static DbContextOptions<WQuizzDBContext> _dbContextOptions;
    private TestWQuizzDBContext _dbContext;
    private IQuizRepository _quizRepository;
    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptionsBuilder<WQuizzDBContext>().UseInMemoryDatabase(databaseName: "WQuizzDB")
            .Options;
        _dbContext = new TestWQuizzDBContext();
        _quizRepository = new QuizRepository(_dbContext);
    }

    [Test]
    public void TheQuizzesAreSeedIntoDatabase()
    {
        var seededData = _quizRepository.GetAll();
        Assert.That(seededData.Count(), Is.EqualTo(4));
    }
}