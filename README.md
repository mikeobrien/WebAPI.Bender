Web API Bender
=============

[![Nuget](http://img.shields.io/nuget/v/WebApi.Bender.svg?style=flat)](http://www.nuget.org/packages/WebApi.Bender/) [![Nuget downloads](http://img.shields.io/nuget/dt/WebApi.Bender.svg?style=flat)](http://www.nuget.org/packages/FubuMVC.Bender/) [![TeamCity Build Status](https://img.shields.io/teamcity/http/build.mikeobrien.net/s/webapibender.svg?style=flat)](http://build.mikeobrien.net/viewType.html?buildTypeId=webapibender&guest=1)

This library integrates [Bender](https://github.com/mikeobrien/Bender) with the [Web API](http://www.asp.net/web-api). 

Installation
------------

    PM> Install-Package WebApi.Bender  

Usage
------------

To enable Bender, simply add the following line to your application bootstrapping:


```csharp
BenderFormatter.Enable();
```

You can configure Bender with the optional DSL as follows:

```csharp
BenderFormatter.Enable(x => x.UseJsonCamelCaseNaming());
```

License
------------

MIT License