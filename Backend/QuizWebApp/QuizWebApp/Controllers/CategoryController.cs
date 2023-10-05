using Microsoft.AspNetCore.Mvc;
using QuizWebApp.Models;

namespace QuizWebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoryController: ControllerBase
{

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
}