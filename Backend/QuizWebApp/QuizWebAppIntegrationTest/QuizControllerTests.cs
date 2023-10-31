using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizWebApp.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace QuizWebAppIntegrationTest;

public class QuizControllerTests
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
    public async Task GetRandomApprovedQuizReturnsAnApprovedQuiz()
    {
        var response = await _client.GetAsync("api/Quiz/GetRandomApprovedQuiz");
        response.EnsureSuccessStatusCode();
        string responseString = await response.Content.ReadAsStringAsync();
        var quiz = JsonConvert.DeserializeObject<Quiz>(responseString);
        Assert.That(quiz.IsApproved, Is.True);
    }
}