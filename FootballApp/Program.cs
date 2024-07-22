using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FootballApp.Services;
using Microsoft.Extensions.Logging;

internal static class Program
{
    private static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var app = ActivatorUtilities.CreateInstance<App>(host.Services);
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<FootballAppServices>();
                services.AddSingleton<FileServices>();
                services.AddSingleton<FootballScoreDisplay>();
                services.AddSingleton<App>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Information);
            });
}
