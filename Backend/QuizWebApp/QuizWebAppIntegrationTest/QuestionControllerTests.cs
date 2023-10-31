using System.Net;
using System.Net.Http.Json;
using QuizWebApp.Models;

namespace QuizWebAppIntegrationTest;

public class QuestionControllerTests
{
    private CustomWebApplicationFactory _factory;
    private HttpClient _client;



    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        
        Environment.SetEnvironmentVariable("WQUIZZ_JWT_VALID_ISSUER", "validIssuer");
        Environment.SetEnvironmentVariable("WQUIZZ_JWT_VALID_AUDIENCE","validAudience");
        Environment.SetEnvironmentVariable("WQUIZZ_JWT_ISSUER_SIGNING_KEY", "issuerSigningKey");
        Environment.SetEnvironmentVariable("WQUIZZ_ADMINUSER_EMAIL", "testing@test.com");
        Environment.SetEnvironmentVariable("WQUIZZ_ADMINUSER_PASSWORD","Admin123");
        
        
        Environment.SetEnvironmentVariable("Environment", "Testing");
        _factory = new CustomWebApplicationFactory();

        _client = _factory.CreateClient();
    }


    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _factory.Dispose();
        _client.Dispose();
    }

    [Test]
    public async Task Post_AddQuestion_ReturnsOk()
    {

        var quiz = _factory._quizRepository.GetById(1);

        var newQuestion = new Question()
        {
            QuizId = quiz.Id,
            QuestionContent = "questionContent",
            Quiz = quiz
        };

        string query = $"api/Question/AddQuestion?quizId={quiz.Id}&questionContent={newQuestion.QuestionContent}";
        var response =
            await _client.PostAsync(query, null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
}