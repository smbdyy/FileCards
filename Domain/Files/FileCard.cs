namespace FileCards.Domain;

public abstract class FileCard
{
    protected FileCard(string path)
    {
        Path = ValidateExtension(path);
    }
    
    public string Description { get; set; } = string.Empty;
    public string Path { get; protected set; }
    public abstract string Extension { get; }

    private string ValidateExtension(string path)
    {
        if (System.IO.Path.GetExtension(path) == Extension)
        {
            return path;
        }

        throw new NotImplementedException();
    }
}