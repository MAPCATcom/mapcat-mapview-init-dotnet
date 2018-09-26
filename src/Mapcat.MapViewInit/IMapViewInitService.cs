using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mapcat.MapViewInit
{
    public interface IMapViewInitService
    {

        Task<MapViewInitResponse> InitRasterView(MapViewInitRequestRaster request);


        Task<MapViewInitResponse> InitVectorView(MapViewInitRequestVector request);

    }
}
