Web API Bender
=============

[![Nuget](http://img.shields.io/nuget/v/WebApi.Bender.svg?style=flat)](http://www.nuget.org/packages/WebApi.Bender/) [![TeamCity Build Status](https://img.shields.io/teamcity/http/build.mikeobrien.net/s/webapibender.svg?style=flat)](http://build.mikeobrien.net/viewType.html?buildTypeId=webapibender&guest=1)

### Bender is no longer being maintained. If you are already using it, consider migrating to an actively developed serializer like JSON.NET.

This library integrates [Bender](https://github.com/mikeobrien/Bender) with the [Web API](http://www.asp.net/web-api). 

Installation
------------

    PM> Install-Package WebApi.Bender  

Usage
------------

To enable Bender, simply add the following line to your application bootstrapping:

```csharp
GlobalConfiguration.Configuration.UseBender();
```

You can configure Bender with the optional DSL as follows:

```csharp
GlobalConfiguration.Configuration.UseBender(x => x.UseJsonCamelCaseNaming());
```

To use Bender for xml or json only you can use the following methods:

```csharp
GlobalConfiguration.Configuration.UseBenderForJson();
GlobalConfiguration.Configuration.UseBenderForXml();
```

License
------------

MIT License