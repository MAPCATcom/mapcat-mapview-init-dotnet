using System;
using System.Collections.Generic;
using System.Text;

namespace Mapcat.MapViewInit
{
    public class MapViewInitRequestBase
    {
        public string Protocol { get; set; } = "https";

        public Dictionary<string, string> Layers { get; set; }
    }
}
