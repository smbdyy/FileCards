using FileCards.Application.Abstractions.DataAccess;
using FileCards.Domain;
using Microsoft.EntityFrameworkCore;

namespace FileCards.DataAccess;

internal class FileCardsDbContext : DbContext, IFileCardsDbContext
{
    public FileCardsDbContext(DbContextOptions<FileCardsDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<FileCard> FileCards { get; protected set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FileCardConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}