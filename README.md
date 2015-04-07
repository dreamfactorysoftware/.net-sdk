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

* DreamFactory - the API library itself
* DreamFactory.Demo - console program demonstrating API usage
* DreamFactory.Tests - Unit Tests (MSTest)

The solution folder also contains ReSharper settings file (team-shared), as well as NuGet package specification file and this README file.

## API

### Basics

All API calls can be logically divided into three layers:

1. Simple HTTP functions, for making arbitrary HTTP requests;
2. Model-driven API,
   e.g. `Session session = await LoginAsync(new Login { email = "john@mail.com", password = "god" });`
3. .NET friendly bindings and extensions, such as Entity Framework interoperability.

All network-related API calls are made asynchronous. They can be `await`'ed and used with Task Parallel Library (TPL).

### Errors handling

- On wrong arguments (preconditions), expect `Argument*Exception` to be thrown,
- On Bad HTTP status codes, expect `DreamFactoryException` to be thrown.

`DreamFactoryException` is normally supplied with a reasonable message when provided by DreamFactory server.

### HTTP API overview

Regular SDK' users will not be dealing with this API unless they have outstanding needs to perform advanced requests.
However, it is very likely that these users will step down this API while debugging, therefore knowing the basics would help developers.

HTTP layer is defined with the following interfaces:

- `IHttpFacade` with the single method SendAsync(),
- `IHttpRequest` that represents an arbitrary HTTP request,
- `IHttpResponse` that represents an HTTP response,

The SDK comes with unirest implementation of `IHttpFacade` - the `UnirestHttpFacade` class. Users can define their own implementations to use them in model-driven APIs.

`IHttpRequest` supports HTTP tunneling, by providing `SetTunneling(HttpMethod)` function. This function modifies the request instance in according with the tunneling feature supported by DreamFactory.

Consider the following example:

```csharp
    string url = "https://www.random.org/cgi-bin/randbyte?nbytes=16&format=h";
    IHttpRequest request = new HttpRequest(HttpMethod.Get, url, new HttpHeaders("Accept", "text/plain"));
    IHttpFacade httpFacade = new UnirestHttpFacade();
    IHttpResponse response = await httpFacade.SendAsync(request);
    Console.WriteLine("Response CODE = {0}, BODY = {1}", response.Code, response.ReadBody());
```

HTTP API supports pluggable serialization. SDK comes with `JsonObjectSerializer` that's built using Json.NET (Newtonsoft).
To use your own serializer, use an alternative constructor that accepts `IObjectSerializer` instance.

### Model driven API overview

All APIs are defined per service and can be obtained by calling `IRestContext.GetService()` method:

```csharp
    IRestContext context = new RestContext(BaseAddress);
    Login login = new Login {email = "user@mail.com", password = "qwerty"};
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

#### REST API versioning

TODO: describe RestApiVersion enumeration and its effect.

#### IRestContext interface

#### HTTP headers management

#### User API

##### Session API

##### Custom API

#### System API

#### Database API

#### Filesystem API

#### Email API

### .NET specific bindings and extensions

