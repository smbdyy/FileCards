using FileCards.Application.Abstractions.DataAccess;
using FileCards.Application.Mapping;
using MediatR;

using static Application.Contracts.GetAllFiles;

namespace FileCards.Application.RequestHandlers.Files;

internal class GetAllFilesHandler : IRequestHandler<Request, Response>
{
    private readonly IFileCardsDbContext _context;

    public GetAllFilesHandler(IFileCardsDbContext context)
    {
        _context = context;
    }
    
    public Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Response(_context.FileCards.Select(card => card.AsDto())));
    }
}