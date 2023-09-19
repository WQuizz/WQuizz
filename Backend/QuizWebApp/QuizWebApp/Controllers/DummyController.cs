using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace QuizWebApp.Controllers;

[ApiController]
[Route("/api/dummy")]
public class DummyController : ControllerBase
{
    [HttpGet]
    public IActionResult GetDummy()
    {
        return Ok("This site is work-in-progress");
    }
}