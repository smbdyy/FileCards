using FileCards.Application.Abstractions.DataAccess;
using FileCards.Application.Extensions;
using MediatR;

using static Application.Contracts.ChangeFileDescription;

namespace FileCards.Application.RequestHandlers.Files;

internal class ChangeFileDescriptionHandler : IRequestHandler<Request>
{
    private readonly IFileCardsDbContext _context;

    public ChangeFileDescriptionHandler(IFileCardsDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(Request request, CancellationToken cancellationToken)
    {
        var fileCard = await _context.FileCards.GetByFilenameAsync(request.Filename, cancellationToken);

        fileCard.Description = request.NewDescription;
        _context.FileCards.Update(fileCard);

        await _context.SaveChangesAsync(cancellationToken);
    }
}