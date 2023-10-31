using System.Net;
using QuizWebApp.Models;

namespace QuizWebAppIntegrationTest;

public class AnswerControllerTests
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
    public async Task AddAnswer_Returns_NotFound_IfInCorrectId()
    {
       /* var question = _factory._questionRepository.GetById(-10);

        var newAnswer = new Answer()
        {
            Question = question,
            AnswerContent = "TEST",
            IsCorrect = true
        };*/

        string query = $"api/Answer/AddAnswer?questionId={999}&answerContent=sd&isCorrect=true";
        
        var response =
            await _client.PostAsync(query, null);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        
    }

    [Test]
    public async Task AddAnswer_Returns_OK_IfExists()
    {
        var question = _factory._questionRepository.GetById(1);

        string query = $"api/Answer/AddAnswer?questionId={question.Id}&answerContent=TEST&isCorrect=true";
        
        var response =
            await _client.PostAsync(query, null);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(question, Is.Not.Null);


    }
    
    
}