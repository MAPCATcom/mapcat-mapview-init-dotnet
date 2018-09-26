using System;
using System.Collections.Generic;
using System.Text;

namespace Mapcat.MapViewInit
{
    public class MapViewInitRequestBase
    {
        public string Protocol { get; set; } = "https";

        public Dictionary<string, string> Layers { get; set; } = new Dictionary<string, string> {
            { Constants.BaseLayers.Base,string.Empty },
            { Constants.BaseLayers.Landcover, string.Empty },
            { Constants.BaseLayers.Ocean,string.Empty },
            { Constants.BaseLayers.Relief,string.Empty }};
    }
}
