namespace FileCards.Domain;

public class FileCard
{
    public static readonly string[] AllowedExtensions = { "txt", "docx", "pdf" };

    public FileCard(string path)
    {
        Path = ValidateExtension(path);
    }
    
    public string Description { get; set; } = string.Empty;
    public string Path { get; private set; }

    private static string ValidateExtension(string path)
    {
        if (AllowedExtensions.Contains(System.IO.Path.GetExtension(path)))
        {
            return path;
        }

        throw new NotImplementedException();
    }
}