using NeoArchiveAI.Domain.Entities;

namespace NeoArchiveAI.Application.Abstractions.Persistence;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<Document>> GetAllAsync();

    Task AddAsync(Document document);

    Task UpdateAsync(Document document);

    Task DeleteAsync(Document document);
}
