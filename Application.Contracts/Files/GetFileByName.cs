using Application.Dto;
using MediatR;

namespace Application.Contracts;

public static class GetFileByName
{
    public record struct Request(string Filename) : IRequest<Response>;

    public record struct Response(FileCardDto File);
}