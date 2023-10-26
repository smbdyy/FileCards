using FileCards.Domain;
using Microsoft.EntityFrameworkCore;

namespace FileCards.Application.Abstractions.DataAccess;

public interface IFileCardsDbContext
{
    DbSet<FileCard> FileCards { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}