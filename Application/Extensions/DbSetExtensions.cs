using FileCards.Domain;
using Microsoft.EntityFrameworkCore;

namespace FileCards.Application.Extensions;

internal static class DbSetExtensions
{
    public static async Task<FileCard> GetByFilenameAsync(
        this DbSet<FileCard> fileCards,
        string filename,
        CancellationToken cancellationToken)
    {
        var card = await fileCards.FindAsync(new object[] { filename }, cancellationToken);

        if (card == null)
        {
            throw new NotImplementedException();
        }

        return card;
    }
}