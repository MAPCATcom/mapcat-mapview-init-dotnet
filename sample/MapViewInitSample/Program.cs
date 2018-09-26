using Mapcat.MapViewInit;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MapViewInitSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Mapcat Map View Init Sample");
            var option = Options.Create<InitOptions>(new InitOptions { APIKey = "jM9oGlsfWxOOYYF0kvuq2UbYl3XrVuUzJmwfnB6M" });
            using (var client = new HttpClient())
            {
                var svc = new MapViewInitService(client, option);
                Console.WriteLine($"Vector Init");
                var result = await svc.InitVectorView(new MapViewInitRequestVector()); //Use default configs
                
                Console.WriteLine($"Url: {result.Url}");
                Console.WriteLine($"StyleSheet: {result.StyleSheet?.Substring(0,100)} ...");
                Console.WriteLine($"********************************************************");
                Console.WriteLine($"Raster Init");
                result = await svc.InitRasterView(new MapViewInitRequestRaster()); //Use default configs

                Console.WriteLine($"Url: {result.Url}");
                Console.WriteLine($"StyleSheet: {result.StyleSheet?.Substring(0, 100)} ...");
            }

            Console.ReadKey();
        }
    }
}
