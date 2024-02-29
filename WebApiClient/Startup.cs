using Orleans;
using Orleans.Hosting;
using Orleans.Configuration;
using GrainInterfaces;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<IClusterClient>(serviceProvider =>
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "OrleansService";
                })
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IUserGrain).Assembly).WithReferences())
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            client.Connect().Wait();
            return client;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}