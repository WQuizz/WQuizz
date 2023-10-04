using Microsoft.AspNetCore.Mvc;
using QuizWebApp.Controllers;
using QuizWebApp.DatabaseServices;
using QuizWebApp.DatabaseServices.Repositories;

namespace QuizWebAppTest;

public class Tests
{
    private QuizController _quizController;
    private IQuizRepository _quizRepository;
    private WQuizzDBContext _quizzDbContext;
    [SetUp]
    public void Setup()
    {
        _quizzDbContext = new WQuizzDBContext();
        _quizRepository = new QuizRepository(_quizzDbContext);
        _quizController = new QuizController(_quizRepository);
    }

    [Test]
    public void QuizzesInsertIntoDatabaseOnStartUp()
    {
        var result = _quizRepository.GetAll();
        Assert.That(result.Count(), Is.EqualTo(2));
    }
}