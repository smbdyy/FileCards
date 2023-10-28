namespace FileCards.Application.Exceptions;

public class FileCardsApplicationException : Exception
{
    public FileCardsApplicationException(string? message) : base(message) { }
}