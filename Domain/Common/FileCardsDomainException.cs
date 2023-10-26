namespace FileCards.Domain.Common;

public class FileCardsDomainException : Exception
{
    public FileCardsDomainException(string? message) : base(message) { }
}