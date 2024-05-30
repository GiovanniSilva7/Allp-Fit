using AllpFit.Impl.Configuration;
using AllpFit.Infra.Context;
using AllpFit.Infra.Interfaces;
using AllpFit.Infra.Interfaces.Contracts;
using AllpFit.Infra.Interfaces.Plans;
using AllpFit.Infra.Repositories.Users;
using AllpFit.Infra.Repositories.Users.Contracts;
using AllpFit.Infra.Repositories.Users.Plans;
using AllpFitApi.Queries.Interfaces;
using AllpFitApi.Queries.UserContext;
using AllpFitApi.Services;
using AllpFitApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Database

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                         new MySqlServerVersion(new Version(8, 4, 0))));

#endregion

#region Auth

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Auth:Issuer"],
        ValidAudience = builder.Configuration["Auth:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

#endregion

#region Dependencies

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserQueries, UserQueries>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IPlansRepository, PlansRepository>();
builder.Services.AddScoped<IPlansQueries, PlansQueries>();
builder.Services.AddScoped<IContractQueries, ContractQueries>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

#endregion

#region Services    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();