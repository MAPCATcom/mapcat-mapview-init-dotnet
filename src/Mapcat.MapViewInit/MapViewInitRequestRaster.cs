using System;
using System.Collections.Generic;
using System.Text;

namespace Mapcat.MapViewInit
{
    public class MapViewInitRequestRaster: MapViewInitRequestBase
    {
        public string Schema { get; set; }
        /// <summary>
        /// ISO Two letters language code
        /// </summary>
        public string Lang { get; set; } = "en";
        /// <summary>
        /// 1 or 2
        /// </summary>
        public byte Scale { get; set; } = 1;
        public bool NoBase { get; set; } = false;
    }
}
