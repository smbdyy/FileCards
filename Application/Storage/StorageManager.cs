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
        var filename = Path.GetFileName(sourceFilePath);
        File.Copy(sourceFilePath, Path.Combine(_storagePath, filename));
    }

    public static bool StorageContainsFile(string filename)
    {
        return File.Exists(Path.Combine(_storagePath, filename));
    }

    public static void DeleteFromStorage(this FileCard file)
    {
        File.Delete(Path.Combine(_storagePath, file.Name));
    }

    public static void RenameInStorage(this FileCard file, string newName)
    {
        File.Move(file.Name, newName);
    }
}