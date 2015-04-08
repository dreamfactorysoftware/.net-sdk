# .NET SDK for the DreamFactory REST API

## Distribution

DreamFactory REST API .NET SDK can be either downloaded from [nuget.org](https://www.nuget.org/packages/DreamFactoryNet) or being built from the source code. The SDK has the only dependency on [unirest-net](http://unirest.io/net.html) library.

### NuGet Package

```powershell
install-package DreamFactoryNet
```

Note that the package is built against .NET 4.5 and if you need a different target version, then build the API from the source code.

### Build From Source Code

Pull the release snapshot and build the solution with Visual Studio 2012 or newer. Note that you will need [NuGet Package Manager extension](https://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c) to be installed.
You can change the target .NET Framework version if needed. The implementation does not use any of 4.5.x specific features, so it can be built with 4.0 with no issues.
When changing the target framework version, pay attention to dependent packages versions (just reinstall them).

## Solution Structure

The Visual Studio solution has three projects:

* DreamFactory       : the API library itself
* DreamFactory.Demo  : console program demonstrating API usage
* DreamFactory.Tests : Unit Tests (MSTest)

The solution folder also contains ReSharper settings file (team-shared), as well as NuGet package specification file and this README file.

## API

### Basics

All API calls are divided into the three groups:

1. Simple HTTP API, for making arbitrary HTTP requests;
2. Model-driven API matching the Swagger definitions,
   e.g. `Session session = await LoginAsync(new Login { email = "john@mail.com", password = "god" });`
3. .NET friendly bindings and extensions, such as Entity Framework interoperability.

Note that all network API calls are made to be asynchronous. They can be `await`'ed and used well together with Task Parallel Library (TPL).

### Errors handling

- On wrong arguments (preconditions), expect `Argument*Exception` to be thrown,
- On Bad HTTP status codes, expect `DreamFactoryException` to be thrown.

`DreamFactoryException` is normally supplied with a reasonable message provided by DreamFactory server.

### HTTP API overview

Regular SDK users should not be dealing with this API unless they have outstanding needs to perform advanced queries.
However, it is very likely that these users will step down this API while debugging, therefore it is recommended to know the basics.

HTTP layer is defined with the following interfaces:

- `IHttpFacade` with the single method `SendAsync()`,
- `IHttpRequest` representing HTTP request,
- `IHttpResponse` representing HTTP response,

The SDK comes with unirest implementation of `IHttpFacade` - the `UnirestHttpFacade` class. Users can define their own implementations to use them in model-driven APIs.

`IHttpRequest` supports HTTP tunneling, by providing `SetTunneling(HttpMethod)` function. This function modifies the request instance in according with the tunneling feature supported by DreamFactory.

Consider the following [example](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/HttpDemo.cs):

```csharp
    string url = "https://www.random.org/cgi-bin/randbyte?nbytes=16&format=h";
    IHttpRequest request = new HttpRequest(HttpMethod.Get, url);
    IHttpFacade httpFacade = new UnirestHttpFacade();
    IHttpResponse response = await httpFacade.SendAsync(request);
    Console.WriteLine("Response CODE = {0}, BODY = {1}", response.Code, response.Body);
```

### Model driven API overview

All APIs are defined per service and can be obtained by calling `IRestContext.GetServiceApi<T>()` method:

```csharp
    IRestContext context = new RestContext(BaseAddress);
    Login login = new Login { email = "user@mail.com", password = "qwerty" };
    IUserSessionApi userSessionApi = context.GetServiceApi<IUserSessionApi>();
    Session session = await userSessionApi.LoginAsync("admin", login);
    Console.WriteLine("Logged in as {0}", session.display_name);
```

Specify service name for creating an interface to a named service:
```csharp
    IRestContext context = new RestContext(BaseAddress);
    IFilesApi filesApi = context.GetServiceApi<IFilesApi>("files");
    await filesApi.CreateFileAsync(...);
```

HTTP API supports pluggable serialization. SDK comes with `JsonObjectSerializer` that is using Json.NET (Newtonsoft).
To use a custom serializer, use a RestContext's constructor accepting an `IObjectSerializer` instance.

#### REST API versioning

Supported API versions defined by `RestApiVersion` enumeration. `V1` is used by default.
SDK uses the version for building the complete URL, e.g. /rest for V1 and /api/v2 for V2.
Building the URL is done transparently to the users.

#### IRestContext interface

Besides the `GetServiceApi<T>()` call, the interface offers services and resources discovery services:

- `GetServicesAsync()`
- `GetResourcesAsync()`

See the demo program for how to use them:
https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/DiscoveryDemo.cs

#### User API

##### Session API

The demo program:
https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/UserSessionDemo.cs

##### Custom API

#### System API

#### Database API

#### Files API

The demo program:
https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/FilesDemo.cs

#### Email API

### .NET specific bindings and extensions

