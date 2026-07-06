using Microsoft.EntityFrameworkCore;
using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Domain.Entities;
using NeoArchiveAI.Domain.Enums;
using NeoArchiveAI.Infrastructure.Persistence.Contexts;

namespace NeoArchiveAI.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.Status != EntityStatus.Deleted);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x =>
                x.Email == email.ToLower() &&
                x.Status != EntityStatus.Deleted);
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        return await _context.Users
            .Where(x => x.Status != EntityStatus.Deleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        return Task.CompletedTask;
    }
}