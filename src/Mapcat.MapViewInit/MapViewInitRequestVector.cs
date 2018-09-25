using System;
using System.Collections.Generic;
using System.Text;

namespace Mapcat.MapViewInit
{
    public class MapViewInitRequestVector: MapViewInitRequestBase
    {
        public StyleType Type { get; set; } = StyleType.Mapbox;

    }
}
