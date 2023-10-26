namespace FileCards.Domain.Common;

public class ValidationException : FileCardsDomainException
{
    public ValidationException(string? message) : base(message) { }

    public static ValidationException InvalidExtension(string filename)
        => new($"Недопустимое расширение файла {filename}");
}