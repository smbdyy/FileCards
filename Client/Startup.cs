using Client.Forms;
using FileCards.Application.Extensions;
using FileCards.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Client;

public static class Startup
{
    public static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddScoped<MainForm>();
        services.AddApplication(new[] { ".txt", ".docx", ".pdf" }, ".\\storage");
        services.AddDataAccess(builder => builder.UseLazyLoadingProxies().UseSqlite("Data Source=database.db"));

        return services.BuildServiceProvider();
    }
}