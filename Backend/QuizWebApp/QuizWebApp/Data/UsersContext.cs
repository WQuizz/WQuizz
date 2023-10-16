﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuizWebApp.Data;

public class UsersContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public UsersContext (DbContextOptions<UsersContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
