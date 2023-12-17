using System.Diagnostics;
using Lab6_Gods.HttpClientPackage;

namespace Lab6_Gods;
using Microsoft.Extensions.DependencyInjection;
public static class Starter
{
    private static async Task Main()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
            
        var serviceProvider = services.BuildServiceProvider();
        var godsServer = serviceProvider.GetService<GodsServer>();

        Debug.Assert(godsServer != null, nameof(godsServer) + " != null");
        await godsServer.RunExperiments(3001, 3002,  
            "rabbitmq://localhost", "guest", "guest", "rabbitmq://localhost/Elon_queue", 
            "rabbitmq://localhost/Mark_queue", 100);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<ColorApiClient>();
        services.AddSingleton<GodsServer>();
            
        // Add other service registrations
    }
}