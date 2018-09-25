using System;
using System.Collections.Generic;
using System.Text;

namespace Mapcat.MapViewInit
{
    public class InitOptions
    {

        public string APIKey { get; set; }

        public string UserAgent { get; set; } = Constants.MAPCAT_DEFAULT_USERAGENT;
    }
}
