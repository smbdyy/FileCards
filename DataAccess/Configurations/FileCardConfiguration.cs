using FileCards.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileCards.DataAccess.Configurations;

internal class FileCardConfiguration : IEntityTypeConfiguration<FileCard>
{
    public void Configure(EntityTypeBuilder<FileCard> builder)
    {
        builder.HasKey(x => x.Name);

        builder
            .Property(x => x.Description)
            .HasMaxLength(FileCard.MaxDescriptionLength);
    }
}