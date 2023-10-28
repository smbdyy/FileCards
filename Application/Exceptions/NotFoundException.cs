namespace FileCards.Application.Exceptions;

public class NotFoundException : FileCardsApplicationException
{
    public NotFoundException(string? message) : base(message) { }

    public static NotFoundException FileInDb(string filename)
        => new($"Файл {filename} не найден в базе данных");

    public static NotFoundException FileInStorage(string filename)
        => new($"Файл {filename} не найден в хранилище");
    
    
}