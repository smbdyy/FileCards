using FileCards.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileCards.DataAccess;

internal class FileCardConfiguration : IEntityTypeConfiguration<FileCard>
{
    public void Configure(EntityTypeBuilder<FileCard> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasMaxLength(FileCard.MaxDescriptionLength);
    }
}