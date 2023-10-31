using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebAppTest.TestContexts;

namespace QuizWebAppIntegrationTest;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{

    public IQuestionRepository _questionRepository { get; }
    public IQuizRepository _quizRepository { get; }
    
    public IAnswerRepository _answerRepository { get; }
    public TestWQuizzDBContext _testWQuizzDbContext { get; }

    public CustomWebApplicationFactory()
    {
        _testWQuizzDbContext = new TestWQuizzDBContext();
        _quizRepository = new QuizRepository(_testWQuizzDbContext);
        _answerRepository = new AnswerRepository(_testWQuizzDbContext);
        _questionRepository = new QuestionRepository(_testWQuizzDbContext);
        


    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        
        

        builder.ConfigureTestServices(services =>
        {
            
            services.AddDbContext<TestWQuizzDBContext>();
            services.AddSingleton(_questionRepository);
            services.AddSingleton(_quizRepository);
            services.AddSingleton(_answerRepository);
            services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();



        });

        builder.UseEnvironment("Testing");
    }
}