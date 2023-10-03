using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices.Repositories;

public interface IQuestionRepository
{
    IEnumerable<Question> GetAll();
    Question? GetById(int id);
    void Add(Question question);
    void Delete(Question question);
    void Update(Question question);
}