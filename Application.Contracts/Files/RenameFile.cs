using MediatR;

namespace Application.Contracts;

public static class RenameFile
{
    public record struct Request(string Filename, string NewFilename) : IRequest;
}