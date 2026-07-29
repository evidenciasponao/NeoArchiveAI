using Microsoft.Extensions.DependencyInjection;
using NeoArchiveAI.Application.Categories.Commands.CreateCategory;
using NeoArchiveAI.Application.Categories.Commands.DeleteCategory;
using NeoArchiveAI.Application.Categories.Commands.UpdateCategory;
using NeoArchiveAI.Application.Categories.Queries.GetCategories;
using NeoArchiveAI.Application.Categories.Queries.GetCategoryById;
using NeoArchiveAI.Application.Documents.Commands.CreateDocument;
using NeoArchiveAI.Application.Documents.Commands.DeleteDocument;
using NeoArchiveAI.Application.Documents.Commands.UpdateDocument;
using NeoArchiveAI.Application.Documents.Queries.GetDocumentById;
using NeoArchiveAI.Application.Documents.Queries.GetDocuments;
using NeoArchiveAI.Application.Users.Commands.CreateUser;
using NeoArchiveAI.Application.Users.Commands.DeleteUser;
using NeoArchiveAI.Application.Users.Commands.UpdateUser;
using NeoArchiveAI.Application.Users.Queries.GetUserById;
using NeoArchiveAI.Application.Users.Queries.GetUsers;

namespace NeoArchiveAI.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Categories
        services.AddScoped<CreateCategoryHandler>();
        services.AddScoped<UpdateCategoryHandler>();
        services.AddScoped<DeleteCategoryHandler>();
        services.AddScoped<GetCategoriesHandler>();
        services.AddScoped<GetCategoryByIdHandler>();

        // Documents
        services.AddScoped<CreateDocumentHandler>();
        services.AddScoped<UpdateDocumentHandler>();
        services.AddScoped<DeleteDocumentHandler>();
        services.AddScoped<GetDocumentsHandler>();
        services.AddScoped<GetDocumentByIdHandler>();

        // Users
        services.AddScoped<CreateUserValidator>();
        services.AddScoped<CreateUserHandler>();

        services.AddScoped<UpdateUserValidator>();
        services.AddScoped<UpdateUserHandler>();

        services.AddScoped<DeleteUserHandler>();

        services.AddScoped<GetUsersHandler>();
        services.AddScoped<GetUserByIdHandler>();

        return services;
    }
}
