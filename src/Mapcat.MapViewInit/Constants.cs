using System;
using System.Collections.Generic;
using System.Text;

namespace Mapcat.MapViewInit
{
    public static class Constants
    {

        public const string MAPCAT_BASE_API_URL = "https://api.mapcat.com";

        public const string MAPCAT_MAPVIEW_INIT_API_PATH = "/api/mapinit";

        public const string MAPCAT_APIKEY_HTTPHEADER_NAME = "X-Api-Key";

        public const string MAPCAT_DEFAULT_USERAGENT = "Mapcat-MapView-Init-Dotnet";

        public static class BaseLayers
        {
            public const string Base = "base";
            public const string Ocean = "ocean";
            public const string Relief = "relief";
            public const string Landcover = "landcover";
        }
    }
}
