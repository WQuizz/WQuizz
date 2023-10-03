using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices.Repositories;

public interface IAnswerRepository
{
    IEnumerable<Answer> GetAll();
    Answer? GetById(int id);
    void Add(Answer answer);
    void Delete(Answer answer);
    void Update(Answer answer);
}