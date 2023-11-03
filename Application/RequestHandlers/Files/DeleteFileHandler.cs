using FileCards.Application.Abstractions.DataAccess;
using FileCards.Application.Extensions;
using FileCards.Application.Storage;
using MediatR;

using static Application.Contracts.DeleteFile;

namespace FileCards.Application.RequestHandlers.Files;

internal class DeleteFileHandler : IRequestHandler<Request>
{
    private readonly IFileCardsDbContext _context;

    public DeleteFileHandler(IFileCardsDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(Request request, CancellationToken cancellationToken)
    {
        var fileCard = _context.FileCards.GetByFilename(request.Filename);
        
        fileCard.DeleteFromStorage();
        _context.FileCards.Remove(fileCard);

        await _context.SaveChangesAsync(cancellationToken);
    }
}