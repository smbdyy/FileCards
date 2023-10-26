using MediatR;

namespace Application.Contracts;

public static class ChangeFileDescription
{
    public record struct Request(string Filename, string NewDescription) : IRequest;
}