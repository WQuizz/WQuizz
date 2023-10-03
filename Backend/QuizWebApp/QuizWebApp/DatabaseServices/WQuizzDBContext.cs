using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices;

public class WQuizzDBContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public WQuizzDBContext()
    {
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (databaseCreator != null)
        {
            if(!databaseCreator.CanConnect()) databaseCreator.Create();
            if(!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Quiz>().HasMany(e => e.Questions)
            .WithOne(e => e.Quiz)
            .HasForeignKey(e => e.QuizId)
            .HasPrincipalKey(e => e.Id);
        builder.Entity<Question>().HasMany(e => e.Answers)
            .WithOne(e => e.Question)
            .HasForeignKey(e => e.QuestionId)
            .HasPrincipalKey(e => e.Id);
    }
}