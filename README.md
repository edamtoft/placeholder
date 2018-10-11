# placeholder
Placeholder Image Service written with Skia and ASP.NET Core

Placeholder is a customizable service for serving your own custom placeholder images similar to services like https://placeholder.com/. You can configure size, text, colors, and more with a variety of convenient presets. You can also configure the home page with custom default colors to fit your brand for easy integration. The application is an [ASP.NET Core](https://www.asp.net/core) application using [Skia](https://skia.org/) and [SkiaSharp](https://github.com/mono/SkiaSharp) for high performance cross-platform image processing.

## Running

With Dotnet Core CLI:

```
git clone https://github.com/edamtoft/placeholder.git
dotnet run placeholder/src/Placeholder
```

With Docker:

```
docker run -p 80:80 edamtoft/placeholder
```

## Configuration

The following environment variables can be used to configure the application:

|Variable               |Description                                    |
|-----------------------|-----------------------------------------------|
|Images:BackgroundColor |Default Background Color                       |
|Images:ForegroundColor |Default Foreground Color                       |
|Images:TextSize        |Default Text Size                              |
|Images:MaxSize         |Max allowed pixel count for images             |
|Page:Title             |Home page title                                |
|Page:Banner            |Home page banner text                          |
|AllowedHosts           |Application Hostname. See ASP.NET Documentation|

## Contributing

Please feel free to submit an issue or pull request.