using Microsoft.EntityFrameworkCore;
using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Domain.Entities;
using NeoArchiveAI.Domain.Enums;
using NeoArchiveAI.Infrastructure.Persistence.Contexts;

namespace NeoArchiveAI.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.Status != DocumentStatus.Deleted);
    }

    public async Task<IReadOnlyList<Category>> GetAllAsync()
    {
        return await _context.Categories
            .Where(x => x.Status != DocumentStatus.Deleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);
        return Task.CompletedTask;
    }
}