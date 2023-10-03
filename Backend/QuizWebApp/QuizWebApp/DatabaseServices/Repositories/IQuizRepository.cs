using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices.Repositories;

public interface IQuizRepository
{
    IEnumerable<Quiz> GetAll();
    Quiz? GetByName(string name);
    void Add(Quiz quiz);
    void Delete(Quiz quiz);
    void Update(Quiz quiz);
}