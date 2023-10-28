using FileCards.Application.Abstractions.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FileCards.DataAccess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> configuration)
    {
        services.AddDbContext<FileCardsDbContext>(configuration);
        services.AddScoped<IFileCardsDbContext>(provider => provider.GetRequiredService<FileCardsDbContext>());

        return services;
    }
}