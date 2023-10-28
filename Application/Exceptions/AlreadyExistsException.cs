namespace FileCards.Application.Exceptions;

public class AlreadyExistsException : FileCardsApplicationException
{
    public AlreadyExistsException(string? message) : base(message) { }

    public static AlreadyExistsException FileInDb(string filename)
        => new($"Файл {filename} уже добавлен в базу данных");

    public static AlreadyExistsException FileInStorage(string filename)
        => new($"Файл {filename} уже есть в хранилище");
}