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
        var fileCard = _context.FileCards.GetByFilename(request.Filename);
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

        _context.FileCards.Remove(fileCard);
        await _context.SaveChangesAsync(cancellationToken);
        
        fileCard.RenameInStorage(newName);
        fileCard.Rename(request.NewFilename);

        _context.FileCards.Add(fileCard);
        await _context.SaveChangesAsync(cancellationToken);
    }
}