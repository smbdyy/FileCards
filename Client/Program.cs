using Client.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Client;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var serviceProvider = Startup.CreateServiceProvider();
        System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<MainForm>());
    }
}