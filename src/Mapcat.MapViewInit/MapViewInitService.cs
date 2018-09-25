using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mapcat.MapViewInit
{
    public class MapViewInitService : IMapViewInitService
    {
        public readonly HttpClient _client;
        public MapViewInitService(HttpClient client, IOptions<InitOptions> options)
        {
            if (client is null)
                throw new ArgumentNullException(nameof(client));

            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (options.Value is null)
                throw new ArgumentNullException(nameof(options.Value));

            if (string.IsNullOrEmpty(options.Value.APIKey))
                throw new ArgumentNullException(nameof(options.Value.APIKey));



            client.BaseAddress = new Uri(Constants.MAPCAT_BASE_API_URL);

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add(Constants.MAPCAT_APIKEY_HTTPHEADER_NAME, options.Value.APIKey);
            client.DefaultRequestHeaders.Add("User-Agent", options.Value.UserAgent);

            _client = client;
        }

        public Task<string> InitRasterView(MapViewInitRequestRaster request)
        {
            return InitView(request);
        }
        public Task<string> InitVectorView(MapViewInitRequestVector request)
        {
            return InitView(request);
        }

        private async Task<string> InitView(MapViewInitRequestBase request)
        {
            var requestPath = Constants.MAPCAT_MAPVIEW_INIT_API_PATH + "/raster";
            if (request is MapViewInitRequestVector)
            {
                requestPath = Constants.MAPCAT_MAPVIEW_INIT_API_PATH + "/vector";
            }
            var dataAsString = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var content = new StringContent(dataAsString);
            var response = await _client.PostAsync(requestPath, content).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return result;
        }

    }
}

