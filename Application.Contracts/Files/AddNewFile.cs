using MediatR;

namespace Application.Contracts;

public static class AddNewFile
{
    public record struct Request(string Filepath, string Description) : IRequest;
}