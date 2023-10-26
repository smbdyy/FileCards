using Application.Dto;
using MediatR;

namespace Application.Contracts;

public static class GetAllFiles
{
    public record struct Request : IRequest<Response>;

    public record struct Response(IEnumerable<FileCardDto> Files);
}