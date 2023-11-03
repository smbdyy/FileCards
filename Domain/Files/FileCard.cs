using FileCards.Domain.Common;

namespace FileCards.Domain;

public class FileCard
{
    public static string[] AllowedExtensions = { ".txt", ".docx", ".pdf" };
    public const int MaxDescriptionLength = 500;

    private string _description = null!;

    public FileCard(Guid id, string name, string description)
    {
        Id = id;
        Name = ValidateExtension(name);
        Description = description;
    }
    
    public Guid Id { get; }
    
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

    public void Rename(string newName)
    {
        string extension = Path.GetExtension(Name);
        Name = newName + extension;
    }

    private static string ValidateExtension(string name)
    {
        if (AllowedExtensions.Contains(Path.GetExtension(name)))
        {
            return name;
        }

        throw ValidationException.InvalidExtension(name);
    }
}