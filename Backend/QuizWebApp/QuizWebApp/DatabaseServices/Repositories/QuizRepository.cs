using Microsoft.EntityFrameworkCore;
using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly WQuizzDBContext _dbContext;

    public QuizRepository(WQuizzDBContext wQuizzDbContext)
    {
        _dbContext = wQuizzDbContext;
    }
    public IEnumerable<Quiz> GetAll()
    {
        return _dbContext.Quizzes.Include(quiz => quiz.Questions).ToList();
    }

    public Quiz? GetByName(string name)
    {
        return _dbContext.Quizzes.Include(quiz => quiz.Questions).
            FirstOrDefault(quiz => quiz.QuizName == name);
    }

    public void Add(Quiz quiz)
    {
        _dbContext.Add(quiz);
        _dbContext.SaveChanges();
    }

    public void Delete(Quiz quiz)
    {
        _dbContext.Remove(quiz);
        _dbContext.SaveChanges();
    }

    public void Update(Quiz quiz)
    {
        _dbContext.Update(quiz);
        _dbContext.SaveChanges();
    }
}