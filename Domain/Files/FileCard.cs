namespace FileCards.Domain;

public class FileCard
{
    public static readonly string[] AllowedExtensions = { ".txt", ".docx", ".pdf" };

    public FileCard(string name)
    {
        Name = ValidateExtension(name);
    }
    
    public string Description { get; set; } = string.Empty;
    public string Name { get; private set; }

    private static string ValidateExtension(string name)
    {
        if (AllowedExtensions.Contains(Path.GetExtension(name)))
        {
            return name;
        }

        throw new NotImplementedException();
    }
}