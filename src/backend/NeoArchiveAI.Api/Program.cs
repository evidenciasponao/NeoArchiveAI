using NeoArchiveAI.Api.Middleware;
using NeoArchiveAI.Application.DependencyInjection;
using NeoArchiveAI.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application
builder.Services.AddApplication();

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Exception Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Development
if (app.Environment.IsDevelopment())
{
    // OpenAPI JSON
    app.MapOpenApi();

    // Swagger JSON
    app.UseSwagger();

    // Swagger UI
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
