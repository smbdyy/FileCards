using FileCards.Application.Abstractions.DataAccess;
using FileCards.Application.Exceptions;
using FileCards.Application.Storage;
using FileCards.Domain;
using MediatR;

using static Application.Contracts.AddNewFile;

namespace FileCards.Application.RequestHandlers.Files;

internal class AddNewFileHandler : IRequestHandler<Request>
{
    private readonly IFileCardsDbContext _context;

    public AddNewFileHandler(IFileCardsDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(Request request, CancellationToken cancellationToken)
    {
        var filename = Path.GetFileName(request.Filepath);

        if (_context.FileCards.Any(file => file.Name == filename))
        {
            throw AlreadyExistsException.FileInDb(filename);
        }

        if (StorageManager.StorageContainsFile(filename))
        {
            throw AlreadyExistsException.FileInStorage(filename);
        }

        StorageManager.AddFileToStorage(request.Filepath);
        
        var fileCard = new FileCard(filename, request.Description);
        _context.FileCards.Add(fileCard);
        await _context.SaveChangesAsync(cancellationToken);
    }
}