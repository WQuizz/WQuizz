using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuizWebApp.Data;
using QuizWebApp.DatabaseServices;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

AddCors();

AddDbContext();
AddServices();
AddAuthentication();
AddIdentity();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


void AddAuthentication()
{
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:WQUIZZ_JWT_VALID_AUDIENCE"],
                ValidAudience = builder.Configuration["Jwt:WQUIZZ_JWT_VALID_AUDIENCE"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("WQUIZZ_JWT_ISSUER_SIGNING_KEY"))
                )
            };
        });
}

void AddIdentity()
{
    builder.Services
        .AddIdentityCore<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        //.AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<UsersContext>();
}

void AddDbContext()
{
    builder.Services.AddDbContext<WQuizzDBContext>();
    builder.Services.AddDbContext<UsersContext>();
}

void AddServices()
{
    builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
    builder.Services.AddTransient<IQuizRepository, QuizRepository>();
    builder.Services.AddTransient<IAnswerRepository, AnswerRepository>();
    builder.Services.AddScoped<IAuthService, AuthService>();
}

void AddCors()
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("*");
            });
    });
}