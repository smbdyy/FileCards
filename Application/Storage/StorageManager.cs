using FileCards.Domain;

namespace FileCards.Application.Storage;

internal static class StorageManager
{
    private static string _storagePath = "\\storage";

    public static string StoragePath
    {
        get => _storagePath;
        set
        {
            if (!Directory.Exists(value))
            {
                Directory.CreateDirectory(value);
            }

            _storagePath = value;
        }
    }

    public static DateTime GetLastEditTime(this FileCard file)
    {
        var info = new FileInfo(Path.Combine(_storagePath, file.Name));
        return info.LastWriteTime;
    }

    public static void AddFileToStorage(string sourceFilePath)
    {
        var name = Path.GetFileName(sourceFilePath);
        File.Move(sourceFilePath, Path.Combine(_storagePath, name));
    }
}