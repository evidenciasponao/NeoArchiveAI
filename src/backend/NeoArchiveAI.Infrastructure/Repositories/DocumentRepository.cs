using Microsoft.EntityFrameworkCore;
using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Domain.Entities;
using NeoArchiveAI.Domain.Enums;
using NeoArchiveAI.Infrastructure.Persistence.Contexts;

namespace NeoArchiveAI.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly ApplicationDbContext _context;

    public DocumentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Document?> GetByIdAsync(Guid id)
    {
        return await _context.Documents
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.Status != EntityStatus.Deleted);
    }

    public async Task<IReadOnlyList<Document>> GetAllAsync()
    {
        return await _context.Documents
            .Where(x => x.Status != EntityStatus.Deleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Document document)
    {
        await _context.Documents.AddAsync(document);
    }

    public Task UpdateAsync(Document document)
    {
        _context.Documents.Update(document);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Document document)
    {
        _context.Documents.Remove(document);
        return Task.CompletedTask;
    }
}