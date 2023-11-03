using FileCards.Application.Exceptions;
using FileCards.Domain;
using Microsoft.EntityFrameworkCore;

namespace FileCards.Application.Extensions;

internal static class DbSetExtensions
{
    public static FileCard GetByFilename(
        this DbSet<FileCard> fileCards,
        string filename)
    {
        var card = fileCards.SingleOrDefault(x => x.Name == filename);

        if (card == null)
        {
            throw NotFoundException.FileInDb(filename);
        }

        return card;
    }
}