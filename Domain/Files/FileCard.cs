using FileCards.Domain.Common;

namespace FileCards.Domain;

public class FileCard
{
    public static readonly string[] AllowedExtensions = { ".txt", ".docx", ".pdf" };

    public FileCard(string name, string description)
    {
        Name = ValidateExtension(name);
        Description = description;
    }
    
    public string Description { get; set; }
    public string Name { get; private set; }

    private static string ValidateExtension(string name)
    {
        if (AllowedExtensions.Contains(Path.GetExtension(name)))
        {
            return name;
        }

        throw ValidationException.InvalidExtension(name);
    }
}