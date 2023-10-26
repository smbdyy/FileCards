using FileCards.DataAccess.Configurations;
using FileCards.Domain;
using Microsoft.EntityFrameworkCore;

namespace FileCards.DataAccess;

internal class FileCardsDbContext : DbContext
{
    public DbSet<FileCard> FileCards { get; protected set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FileCardConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}