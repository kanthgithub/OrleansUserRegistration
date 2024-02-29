using System.Reflection;
using System.Threading.Tasks;
using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace SiloHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "OrleansService";
                })
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IUserGrain).Assembly).WithReferences())
                    .ConfigureLogging(logging => logging.AddConsole())
                        .UseDashboard(options => {}) // This line enables the Orleans Dashboard
                .Build();

            await host.StartAsync();

            await Task.Delay(-1);}
    }
}