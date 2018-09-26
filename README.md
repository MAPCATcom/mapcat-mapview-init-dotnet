# Mapcat Map view Init Dotnet

This is a Mapcat map view initialization NetStandard 2.0 library what you can use to init raster or vector map in UWP, Xamarin application

## Build

`dotnet build`

## Usage

### Simple
            
```            
using Mapcat.MapViewInit;  
using Microsoft.Extensions.Options; 

var option = Options.Create<InitOptions>(new InitOptions { APIKey = "< Your MAPCAT Visualization API key >" });
    using (var client = new HttpClient())
    {
        var svc = new MapViewInitService(client, option);

        var result = await svc.InitVectorView(new MapViewInitRequestVector()); //Use default configs
        result = await svc.InitRasterView(new MapViewInitRequestRaster()); //Use default configs
    }
```
### Dependency Injection

```            
using Mapcat.MapViewInit;  
using Microsoft.Extensions.Options; 

//Configuration
services.AddHttpClient<MapViewInitService>();
services.Configure<InitOptions>(opt =>
{
    opt.APIKey = "jM9oGlsfWxOOYYF0kvuq2UbYl3XrVuUzJmwfnB6M";
})

//Injected in constructor or get from container
var svc = serviceProvider.GetService<MapViewInitService>();
var result = await svc.InitVectorView(new MapViewInitRequestVector()); //Use default configs
result = await svc.InitRasterView(new MapViewInitRequestRaster()); //Use default configs

```



Substitute `< Your MAPCAT Visualization API key >` with your Visualization API key.  

Read [MAPCAT for Developers](https://docs.mapcat.com) for more information and examples.

## Licence
[MIT Licence](https://github.com/MAPCATcom/mapcat-mapview-init/blob/master/LICENSE)