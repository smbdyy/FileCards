using FileCards.Application.Abstractions.DataAccess;
using FileCards.Application.Extensions;
using FileCards.Application.Mapping;
using MediatR;

using static Application.Contracts.GetFileByName;

namespace FileCards.Application.RequestHandlers.Files;

internal class GetFileByNameHandler : IRequestHandler<Request, Response>
{
    private readonly IFileCardsDbContext _context;

    public GetFileByNameHandler(IFileCardsDbContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var fileCard = await _context.FileCards.GetByFilenameAsync(request.Filename, cancellationToken);

        return new Response(fileCard.AsDto());
    }
}