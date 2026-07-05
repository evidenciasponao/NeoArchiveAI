using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeoArchiveAI.Application.Abstractions.Hashing;
using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Abstractions.Storage;
using NeoArchiveAI.Infrastructure.Hashing;
using NeoArchiveAI.Infrastructure.Persistence;
using NeoArchiveAI.Infrastructure.Persistence.Contexts;
using NeoArchiveAI.Infrastructure.Repositories;
using NeoArchiveAI.Infrastructure.Storage;

namespace NeoArchiveAI.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        // Repositories
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        // Services
        services.AddScoped<IFileStorageService, LocalFileStorageService>();
        services.AddScoped<IHashService, Sha256HashService>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}