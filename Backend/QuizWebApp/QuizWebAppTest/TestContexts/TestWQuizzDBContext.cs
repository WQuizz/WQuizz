using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Net.Http.Headers;
using QuizWebApp.DatabaseServices;
using QuizWebApp.Models;

namespace QuizWebAppTest.TestContexts;

public class TestWQuizzDBContext : WQuizzDBContext
{
    public TestWQuizzDBContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "WQuizzDB");
    }
    
}