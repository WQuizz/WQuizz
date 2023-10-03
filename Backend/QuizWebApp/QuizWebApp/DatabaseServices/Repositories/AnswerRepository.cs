using Microsoft.EntityFrameworkCore;
using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly WQuizzDBContext _dbContext;

    public AnswerRepository(WQuizzDBContext wQuizzDbContext)
    {
        _dbContext = wQuizzDbContext;
    }
    public IEnumerable<Answer> GetAll()
    {
        return _dbContext.Answers.Include(answer => answer.Question).ToList();
    }

    public Answer? GetById(int id)
    {
        return _dbContext.Answers.Include(answer => answer.Question)
            .FirstOrDefault(answer => answer.Id == id);
    }

    public void Add(Answer answer)
    {
        _dbContext.Add(answer);
        _dbContext.SaveChanges();
    }

    public void Delete(Answer answer)
    {
        _dbContext.Remove(answer);
        _dbContext.SaveChanges();
    }

    public void Update(Answer answer)
    {
        _dbContext.Update(answer);
        _dbContext.SaveChanges();
    }
}