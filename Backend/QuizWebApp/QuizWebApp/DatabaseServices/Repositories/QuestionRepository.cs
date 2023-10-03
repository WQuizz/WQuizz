using Microsoft.EntityFrameworkCore;
using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly WQuizzDBContext _dbContext;

    public QuestionRepository(WQuizzDBContext wQuizzDbContext)
    {
        _dbContext = wQuizzDbContext;
    }
    public IEnumerable<Question> GetAll()
    {
        return _dbContext.Questions.Include(question => question.Quiz).
            Include(question => question.Answers).ToList();
    }

    public Question? GetById(int id)
    {
        return _dbContext.Questions.Include(question => question.Quiz).Include(question => question.Answers)
            .FirstOrDefault(question => question.Id == id);
    }

    public void Add(Question question)
    {
        _dbContext.Add(question);
        _dbContext.SaveChanges();
    }

    public void Delete(Question question)
    {
        _dbContext.Remove(question);
        _dbContext.SaveChanges();
    }

    public void Update(Question question)
    {
        _dbContext.Update(question);
        _dbContext.SaveChanges();
    }
}