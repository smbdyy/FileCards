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
    
    public Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var fileCard = _context.FileCards.GetByFilename(request.Filename);

        return Task.FromResult(new Response(fileCard.AsDto()));
    }
}