using FileCards.Domain.Common;

namespace FileCards.Domain;

public class FileCard
{
    public static readonly string[] AllowedExtensions = { ".txt", ".docx", ".pdf" };
    public const int MaxDescriptionLength = 500;

    private string _description = null!;

    public FileCard(string name, string description)
    {
        Name = ValidateExtension(name);
        Description = description;
    }
    
    public string Description
    {
        get => _description;
        set
        {
            if (value.Length > MaxDescriptionLength)
            {
                throw ValidationException.DescriptionTooLong();
            }

            _description = value;
        }
    }
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