using FileCards.Application.Storage;
using FileCards.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace FileCards.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IEnumerable<string> allowedFileExtensions,
        string storagePath)
    {
        FileCard.AllowedExtensions = allowedFileExtensions.ToArray();
        StorageManager.StoragePath = storagePath;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IAssemblyMarker>());

        return services;
    } 
}