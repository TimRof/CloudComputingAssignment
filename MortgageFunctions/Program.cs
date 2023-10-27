using Entities.Models.Mortgage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Mortgage;
using ServiceLayer.Email;
using ServiceLayer.Mortgage;

class Program
{
    static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices((context, services) =>
            {
                services.AddHttpClient();

            })
            .Build();

        host.Run();
    }
}
