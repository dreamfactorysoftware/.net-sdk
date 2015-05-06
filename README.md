![Build status](https://travis-ci.org/dreamfactorysoftware/.net-sdk.svg)

# .NET SDK for the DreamFactory REST API

## Distribution

DreamFactory REST API .NET SDK can be either downloaded from [nuget.org](https://www.nuget.org/packages/DreamFactoryNet) or being built from the source code. The SDK has the only dependency on [unirest-net](http://unirest.io/net.html) library.

The SDK has been tested on the following platforms:

* Windows 7 with Visual Studio 2012 and 2013
* Windows 8.1 with Visual Studio 2013
* Windows 10 with Visual Studio 2015 CTP
* Mac OS X (Yosemite) with Xamarin 

### NuGet Package

```powershell
install-package DreamFactoryNet
```

Note that the package is built against .NET 4.5 and if you need a different target version, then build the API from the source code.

### Building From Source Code

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

The API provides the following functions:

1. Simple HTTP API, for making arbitrary HTTP requests;
2. Model-driven API matching the Swagger definitions,
   e.g. `Session session = await LoginAsync("admin", "john@mail.com", "god");`
3. Model extensions and builders to ease working with object instances.

All network-related API calls are made to be asynchronous. They can be `await`'ed and used well together with Task Parallel Library (TPL).

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

Consider the following [example](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/HttpDemo.cs):

```csharp
    string url = "https://www.random.org/cgi-bin/randbyte?nbytes=16&format=h";
    IHttpRequest request = new HttpRequest(HttpMethod.Get, url);
    IHttpFacade httpFacade = new UnirestHttpFacade();
    IHttpResponse response = await httpFacade.SendAsync(request);
    Console.WriteLine("Response CODE = {0}, BODY = {1}", response.Code, response.Body);
```

### Model driven API overview

All APIs are defined per service and can be obtained via `IRestContext.Factory` methods:

```csharp
    IRestContext context = new RestContext(BaseAddress);
    IUserApi userApi = context.Factory.CreateUserApi();
    Session session = await userApi.LoginAsync("admin", "user@mail.com", "qwerty");
    Console.WriteLine("Logged in as {0}", session.display_name);
```

Specify service name for creating an interface to a named service:
```csharp
    IRestContext context = new RestContext(BaseAddress);
    IFilesApi filesApi = context.Factory.CreateFilesApi("files");
    await filesApi.CreateFileAsync(...);
```

HTTP API supports pluggable serialization. SDK comes with `JsonContentSerializer` that is using Json.NET (Newtonsoft).
To use a custom serializer, use the other `RestContext` constructor accepting an `IContentSerializer` instance.

#### REST API versioning

Supported API versions defined by `RestApiVersion` enumeration. `V1` is used by default.
SDK uses the version for building the complete URL, e.g. /rest for V1 and /api/v2 for V2.
Building the URL is done transparently to the users.

#### IRestContext interface

Besides the `IRestContext.Factory` object, the interface offers services and resources discovery functions:

- `GetServicesAsync()`
- `GetResourcesAsync()`

See the [demo program](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/DiscoveryDemo.cs) for usage details.

#### User API

> See [IUserApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/IUserApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/UserDemo.cs)

##### Notes on user session management

All API calls require Application-Name header to be set and many others require Session-ID header. Here is how these headers are managed by SDK:

* Both Application-Name and Session-ID headers are being set upon `IUserApi.LoginAsync()` completion,
* Session-ID header gets removed upon `IUserApi.LogoutAsync()` completion,
* Session-ID header gets updated if another login is made during `passwordChange()` call.

To use/set another Application-Name, simply perform another `LoginAsync` call with a new `applicationName` parameter.

#### CustomSettings API

> See [ICustomSettingsApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/ICustomSettingsApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/CustomSettingsDemo.cs)

The API can be created for user and system namespace.

Because the SDK is targeting .NET users, the primary focus is made towards strong-typing, rather than duck-typing.
To deal with a custom setting, a user must have the corresponding DTO class matching the setting's schema.
Please refer to the demo for sample API usage.

#### Files API

> See [IFilesApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/IFilesApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/FilesDemo.cs)

Summary on supported features:
* CRUD operations on containers, folders and files,
* Bulk files uploading/downloading in ZIP format,
* Text and binary files reading/writing.

##### Notes on metadata support

Reading/Writing of metadata associated with file entities (container, folder, file) are not supported yet.

#### Database API

> See [IDatabaseApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/IDatabaseApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/DatabaseDemo.cs)

#### Notes on schema management

To simplify `TableSchema` construction, SDK offers `TableSchemaBuilder` class that implement Code First approach:
```csharp
        // Your custom POCO
        class StaffRecord
        {
            public int uid { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int age { get; set; }
		}

		// Create tabe schema from StaffRecord type
		ITableSchemaBuilder builder = new TableSchemaBuilder();
        builder.WithName(TableName).WithFieldsFrom<StaffRecord>().WithKeyField("uid").Build();
```

API does not offer schema operations on dedicated fields. Use `UpdateTableAsync` method to update any table's schema.
Related entities (records) are not retrieved (see related query parameter).

#### Notes on table records operations

* Input/Output is always a user-defined POCO classes that must match the corresponding table's schema;
* `CreateRecordsAsync` returns the created records back to user with key fields (IDs) updated;
* `GetRecordsAsync` has three overloads to retrieve: all records, records by ids and by given SQL query.

#### Notes on stored procedures/functions

When calling a stored procedure or function, some overloads use a collection of `StoreProcParams` instances. To simplify creating such a collection, consider using `StoreProcParamsBuilder` class.
When response (or return values) is expected, a user must define `TStoredProcResponse` POCO that shall have fields for OUT-parameters and for wrapper.
It's recommended to read the technical notes on stored procedures: https://github.com/dreamfactorysoftware/dsp-core/wiki/SQL-Stored-Procedures

#### Email API

> See [IEmailApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/IEmailApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/EmailDemo.cs)

Sending an email will require `EmailRequest` object to be built.
For an advanced use, construct this object manually by providing all essential information.
For a simple use, consider using `EmailRequestBuilder` class that lets you building a request in few simple steps:

```csharp
EmailRequest request = new EmailRequestBuilder()
							.AddTo("inbox@mail.com")
							.WithSubject("Hello")
							.WithBody("Hello, world!")
							.Build();
```

#### System API

> See [ISystemApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/ISystemApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/SystemDemo.cs)

##### Current limitations

* Reading/writing of metadata related to system records are not supported.
* `EnvironmentResponse` has `PhpInfoSection` object is ignored on read.
* Related entities are not retrieved (see related query parameter).
* Unregister event listeners is not supported.
* Provider and UserProvider APIs are not supported.
