using Mapcat.MapViewInit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MapViewInitSampleDependencyInjection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(b =>
                {
                    b.AddFilter((category, level) => true); // Spam the world with logs.
                    b.AddConsole();
                })
                .AddHttpClient<MapViewInitService>().Services
                .Configure<InitOptions>(opt =>
                {
                    opt.APIKey = "jM9oGlsfWxOOYYF0kvuq2UbYl3XrVuUzJmwfnB6M";
                })
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");


            var svc = serviceProvider.GetService<MapViewInitService>();
            logger.LogDebug($"Vector Init");
            var result = await svc.InitVectorView(new MapViewInitRequestVector()); //Use default configs

            logger.LogDebug($"Url: {result.Url}");
            logger.LogDebug($"StyleSheet: {result.StyleSheet?.Substring(0, 100)} ...");
            logger.LogDebug($"********************************************************");
            logger.LogDebug($"Raster Init");
            result = await svc.InitRasterView(new MapViewInitRequestRaster()); //Use default configs

            logger.LogDebug($"Url: {result.Url}");
            logger.LogDebug($"StyleSheet: {result.StyleSheet?.Substring(0, 100)} ...");
            //do the actual work here

            logger.LogDebug("All done!");

            Console.ReadKey();
        }
    }
}
