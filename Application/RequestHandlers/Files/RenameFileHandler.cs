using FileCards.Application.Abstractions.DataAccess;
using FileCards.Application.Exceptions;
using FileCards.Application.Extensions;
using FileCards.Application.Storage;
using MediatR;

using static Application.Contracts.RenameFile;

namespace FileCards.Application.RequestHandlers.Files;

internal class RenameFileHandler : IRequestHandler<Request>
{
    private readonly IFileCardsDbContext _context;

    public RenameFileHandler(IFileCardsDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(Request request, CancellationToken cancellationToken)
    {
        var fileCard = await _context.FileCards.GetByFilenameAsync(request.Filename, cancellationToken);
        string extension = Path.GetExtension(fileCard.Name);
        string newName = request.NewFilename + extension;
        
        if (_context.FileCards.Any(file => file.Name == newName))
        {
            throw AlreadyExistsException.FileInDb(newName);
        }

        if (StorageManager.StorageContainsFile(newName))
        {
            throw AlreadyExistsException.FileInStorage(newName);
        }
        
        fileCard.Rename(newName);
        fileCard.RenameInStorage(newName);

        _context.FileCards.Update(fileCard);
        await _context.SaveChangesAsync(cancellationToken);
    }
}