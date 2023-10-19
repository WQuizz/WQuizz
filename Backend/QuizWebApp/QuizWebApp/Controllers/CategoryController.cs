using Microsoft.AspNetCore.Mvc;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoryController: ControllerBase
{
    private readonly IQuizRepository _quizRepository;
    public CategoryController(IQuizRepository quizRepositry)
    {
        _quizRepository = quizRepositry;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var values = Enum.GetValues(typeof(Category));
        List<string> valueStrings = new List<string>();
        foreach (var value in values)
        {
            valueStrings.Add(Enum.GetName(typeof(Category),value));
        }
        return Ok(valueStrings);
    }

    [HttpGet("byName/{categoryName}")]
    public IActionResult GetQuizByCategoryName(string categoryName)
    {
        return Ok(_quizRepository.GetAll().Where(quiz => quiz.CategoryType.ToString() == categoryName));
    }
}