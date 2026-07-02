using Microsoft.Extensions.DependencyInjection;
using NeoArchiveAI.Application.Documents.Commands.CreateDocument;
using NeoArchiveAI.Application.Documents.Queries.GetDocumentById;
using NeoArchiveAI.Application.Documents.Queries.GetDocuments;

namespace NeoArchiveAI.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<CreateDocumentHandler>();

        services.AddScoped<GetDocumentByIdHandler>();

        services.AddScoped<GetDocumentsHandler>();

        return services;
    }
}