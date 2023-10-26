using MediatR;

namespace Application.Contracts;

public static class DeleteFile
{
    public record struct Request(string Filename) : IRequest;
}