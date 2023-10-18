using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuizWebApp.DatabaseServices;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;
using QuizWebApp.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

AddCors();
AddDbContext();
AddServices();
AddAuthentication();
AddIdentity();
ConfigureSwagger();

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

AddRoles();
AddAdmin();

app.Run();


void AddCors()
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        options.AddPolicy("AllowLocalhost", policy =>
        {
            policy
                .WithOrigins("http://localhost:3000", "http://localhost:3001") // Allow requests from your client's origin
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
}

void AddDbContext()
{
    builder.Services.AddDbContext<WQuizzDBContext>();
}

void AddServices()
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
    builder.Services.AddTransient<IQuizRepository, QuizRepository>();
    builder.Services.AddTransient<IAnswerRepository, AnswerRepository>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
}

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
                ValidIssuer = Environment.GetEnvironmentVariable("WQUIZZ_JWT_VALID_ISSUER"),
                ValidAudience = Environment.GetEnvironmentVariable("WQUIZZ_JWT_VALID_AUDIENCE"),
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("WQUIZZ_JWT_ISSUER_SIGNING_KEY"))
                )
            };
        });
}

void AddIdentity()
{
    builder.Services
        .AddIdentityCore<ApplicationUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<WQuizzDBContext>();
}

void ConfigureSwagger()
{
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    });
}

void AddRoles()
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var tAdmin = CreateAdminRole(roleManager);
    tAdmin.Wait();

    var tUser = CreateUserRole(roleManager);
    tUser.Wait();
}

async Task CreateAdminRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole(builder.Configuration["Roles:Admin"]));
}

async Task CreateUserRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole(builder.Configuration["Roles:User"]));
}

void AddAdmin()
{
    var tAdmin = CreateAdminIfNotExists();
    tAdmin.Wait();
}

async Task CreateAdminIfNotExists()
{
    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<WQuizzDBContext>();
    var adminInDb = await userManager.FindByEmailAsync("admin@admin.com");
    if (adminInDb == null)
    {
        

        var admin = new ApplicationUser
        {
            UserName = Environment.GetEnvironmentVariable("WQUIZZ_ADMINUSER_USERNAME"),
            Email = Environment.GetEnvironmentVariable("WQUIZZ_ADMINUSER_EMAIL"),
            UserProfile = null
        };
        
        var adminCreated = await userManager.CreateAsync(admin, Environment.GetEnvironmentVariable("WQUIZZ_ADMINUSER_PASSWORD"));

        if (adminCreated.Succeeded)
        {
            var userProfile = new UserProfile
            {
                UserId = admin.Id,
                DisplayName = Environment.GetEnvironmentVariable("WQUIZZ_ADMINUSER_USERNAME"),
                ProfilePicture = null
                // You can set ProfilePicture to null or a default value if needed
            };
            
            dbContext.UserProfiles.Add(userProfile);
            await dbContext.SaveChangesAsync(); // Save the UserProfile to generate an Id
            admin.UserProfile = userProfile;
            admin.ProfileId = userProfile.Id;
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
