[![Build Status](https://travis-ci.org/dreamfactorysoftware/.net-sdk.svg?branch=release-2.0)](https://travis-ci.org/dreamfactorysoftware/.net-sdk)
[![NuGet](https://img.shields.io/nuget/v/DreamFactoryNet.svg?style=flat)](http://www.nuget.org/packages/DreamFactoryNet/)

# .NET SDK for the DreamFactory REST API

The .NET SDK provides classes and interfaces to access the DreamFactory REST API.

## Quick links
- [Solution structure](#solution-structure)
- [Distribution](#distribution)
	- [Dependencies](#dependencies)
	- [Building from Source Code](#building-from-source-code)
- [Demo](#demo)
	- [Running the Console Demo](#running-the-console-demo)
	- [Running the Address Book demo](#running-the-address-book-demo)
- [API overview](#api)
	- [User](#user-api)
	- [CustomSettings](#customsettings-api)
	- [Files](#files-api)
	- [Database](#database-api)
	- [Email](#email-api)
	- [System](#system-api)
	
## Solution structure

The Visual Studio solution has these projects:

* DreamFactory       : the API library
* DreamFactory.Demo  : console program demonstrating API usage (with some integration tests)
* DreamFactory.Tests : Unit Tests (MSTest)
* DreamFactory.AddressBook : ASP.NET MVC web app demonstrating API usage in a real world example.

The solution folder also contains:

* ReSharper settings file (team-shared),
* NuGet package specification file,
* this README file.

## Distribution

The package can be either installed from [nuget.org](https://www.nuget.org/packages/DreamFactoryNet) or simply built from the source code with Visual Studio.

```powershell
install-package DreamFactoryNet
```

Alternatively, check this article on how to manage NuGet packages in Visual Studio:
[https://docs.nuget.org/consume/installing-nuget](https://docs.nuget.org/consume/installing-nuget)

### Dependencies

The API has been built with [unirest-net](http://unirest.io/net.html) library. Although the underlying HTTP layer can be substituted (see further), it's recommended to use the default implementation.

unirest-net, in turn, has the following dependencies:

- `Microsoft.Bcl (≥ 1.1.10)`
- `Microsoft.Bcl.Build (≥ 1.0.21)`
- `Microsoft.Bcl.Async (≥ 1.0.168)`
- `Newtonsoft.Json (≥ 7.0.1)`
- `Microsoft.Net.Http (≥ 2.2.29)`

Supported platforms:

* ASP.NET 4.5, 4,6
* ASP.NET 5
* Android (Xamarin)
* iOS (Xamarin)
* WinRT and WinRT Phone (Windows 8 and Phone 8.1)
* Windows Phone Silverlight 8

At this moment UAP10.0 (Universal App Platform) is not supported because of the dependancy on unirest-net that doesn't support that target.

### Building from Source Code

Pull the release snapshot and build the solution with Visual Studio 2012 or newer. Note that you will need [NuGet Package Manager extension](https://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c) to be installed.
You can change the target .NET Framework version if needed. The implementation does not use any of 4.5.x specific features, so it can be built with .NET 4.0.
When changing the target framework version, pay attention to the dependent package versions - you will need to reinstall them:

```powershell
	update-package -reinstall -ignoreDependencies
```

## Demo

To run the demos, you need to install [DreamFactory stack](https://bitnami.com/stack/dreamfactory) on your machine.

### Running the Console Demo

Console demo requires a test user to be specified in Program.cs file. Open the file and modify the settings to match your setup.
```csharp
	internal const string BaseAddress = "http://localhost:8080";
	internal const string AppName = "<app_name>";
	internal const string AppApiKey = "<app_api_key>";
	internal const string Email = "<user_email>";
	internal const string Password = "<user_password>";
```

 > Note that the test user must have a role which allows any HTTP verbs on any services/resources.

* Open DreamFactoryNet solution in Visual Studio 2012 or newer;
* Open Program.cs and modify the settings;
* In *Solution Explorer* window find *DreamFactory.Demo* project, right-click on it and select *Set as StartUp project*;
* In Visual Studio main menu, select *DEBUG -> Run without debugging*;
* A console window will appear with demo output;
* If the demo has been completed successfully, you will see the total number of tests executed. 

### Running the Address Book Demo

Configure the DreamFactory instance to run the app:

- Enable [CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing) for development purposes.
	- In the admin console, navigate to the Config tab and click on CORS in the left sidebar.
	- Click Add.
	- Set Origin, Paths, and Headers to *.
	- Set Max Age to 0.
	- Allow all HTTP verbs and check the Enabled box.
	- Click update when you are done.
	- More info on setting up CORS is available [here](https://github.com/dreamfactorysoftware/dsp-core/wiki/CORs-Configuration).

- Create a default role for new users and enable open registration
	- In the admin console, click the Roles tab then click Create in the left sidebar.
	- Enter a name for the role and check the Active box.
	- Go to the Access tab.
	- Add a new entry under Service Access (you can make it more restrictive later).
		- set Service = All
		- set Component = *
		- check all HTTP verbs under Access
		- set Requester = API
	- Click Create Role.
	- Click the Services tab, then edit the user service. Go to Config and enable Allow Open Registration.
	- Set the Open Reg Role Id to the name of the role you just created.
	- Make sure Open Reg Email Service Id is blank, so that new users can register without email confirmation.
	- Save changes.

- Import the package file for the app.
	- From the Apps tab in the admin console, click Import and the DreamFactory.AddressBook project for add_dotnet.dfpkg in App_Package folder. The Address Book package contains the application description, schemas, and sample data.
	- Leave storage service and folder blank because this app will be running locally.
	- Click the Import button. If successful, your app will appear on the Apps tab. You may have to refresh the page to see your new app in the list.
	
- Make sure you have a SQL database service named 'db'. Depending on how you installed DreamFactory you may or may not have a 'db' service already available on your instance. You can add one by going to the Services tab in the admin console and creating a new SQL service. Make sure you set the name to 'db'.

- The demo also requires a couple of constants to be specified in DreamFactoryContext.cs file located in the DreamFactory.AddressBook project. Open the file and modify the settings to match your setup.
```csharp
	public const string BaseAddress = "http://localhost:8080";
	public const string AppName = "<app_name>";
	public const string AppApiKey= "<app_api_key>";
	public const RestApiVersion Version = RestApiVersion.V2;
	public const string DbServiceName = "db";
	public const string FileServiceName = "files";
```

You can now run the app by starting the DreamFactory.AddressBook project in your browser. When the app starts up you can register a new user, or log in as an existing user (ex. admin you've set up first time you opened DreamFactory admin app).

## API

### Basics

The API provides the following functions:

1. Simple HTTP API, for making arbitrary HTTP requests;
2. DreamFactory API (closely matching the Swagger definition),
3. Various extensions and builders to simplify managing DreamFactory models.

All network-related API calls are asynchronous, they all have `Async` suffix.
The IO-bound calls (HTTP request and stream IO) have `ConfigureAwait(false)`.

### Errors handling

- On wrong arguments (preconditions), expect `Argument*Exception` to be thrown.
- On Bad HTTP status codes, expect `DreamFactoryException` to be thrown.
> `DreamFactoryException` is normally supplied with a reasonable message provided by DreamFactory server, unless it fails with an HTML page returned with the response.

- On content serialization errors (JSON by default), expect Json.NET exceptions to be thrown.
> Serialization may fail if returned objects do not match the strongly-typed entities defined with the API.
> This may happen in particular when DreamFactory services change their contract in a breaking way.   

### HTTP API overview

Regular users would not deal with this API subset unless they have outstanding needs to perform advanced queries.
However, it is very likely that these users will step down this API while debugging, therefore it is recommended to know the basics.

HTTP layer is defined with the following interfaces:

- `IHttpFacade` with the single method `SendAsync()`,
- `IHttpRequest` representing an HTTP request,
- `IHttpResponse` representing an HTTP response,

The SDK comes with unirest-net implementation of `IHttpFacade` - the `UnirestHttpFacade` class. A user can define its own implementation to use it with DreamFactory API. Providing a custom `IHttpFacade` instance could be useful for mocking purposes and IoC. 

`IHttpRequest` supports HTTP tunneling, by providing `SetTunneling(HttpMethod)` function. This function modifies the request instance in according with the tunneling feature supported by DreamFactory.

Here is an [example](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/HttpDemo.cs):

```csharp
	string url = "https://www.random.org/cgi-bin/randbyte?nbytes=16&format=h";
	IHttpRequest request = new HttpRequest(HttpMethod.Get, url);
	IHttpFacade httpFacade = new UnirestHttpFacade();
	IHttpResponse response = await httpFacade.SendAsync(request);
	Console.WriteLine("Response CODE = {0}, BODY = {1}", response.Code, response.Body);
```

### DreamFactory API overview

Each DreamFactory's service has a corresponding interface that exposes all functions you could find in Swagger definition. Some functions, however, were split and some were reduced to remain reasonable and consistent to .NET users.

The service instances are created with `IRestContext.Factory` methods:

```csharp
	IRestContext context = new RestContext(BaseAddress);
	IUserApi userApi = context.Factory.CreateUserApi();
	Session session = await userApi.LoginAsync("demo", "api_key", "user@mail.com", "qwerty");
	Console.WriteLine("Logged in as {0}", session.display_name);
```

Specify service name for creating an interface to a named service:
```csharp
	IRestContext context = new RestContext(BaseAddress);
	IFilesApi filesApi = context.Factory.CreateFilesApi("files");
	await filesApi.CreateFileAsync(...);
```

#### Serialization

The API supports pluggable serialization. This SDK comes with the default `JsonContentSerializer` which is using [Json.NET](http://www.newtonsoft.com/json).
To use your custom serializer, consider using the other `RestContext` constructor accepting a user-defined `IContentSerializer` instance.

#### SQL query parameters

Most DreamFactory resources persist in the system database, e.g. Users, Apps, Services. When calling CRUD API methods accessing these resources be prepared to deal with related SQL query parameters. All such APIs accept a `SqlQuery` class instance. You can populate any fields of this class, but do check swagger contract for the service you about to use. The API implementation will set any non-null fields as query parameters.

Default `SqlQuery` constructor populates the single property: *fields=**. This results in all fields to be read.

#### REST API versioning

Supported API versions defined by `RestApiVersion` enumeration. `V2` is used by default.
The SDK uses version for building the complete URL, e.g. /rest for V1 and /api/v2 for V2.
Note that building the URL is done transparently to the users.

#### IRestContext interface

Besides the `IRestContext.Factory` object which is designed to construct service instances, the interface offers few discovery functions:

- `GetServicesAsync()`
- `GetResourcesAsync()`

See the [demo program](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/DiscoveryDemo.cs) for usage details.

#### User API

> See [IUserApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/IUserApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/UserDemo.cs)

##### Notes on user session management

All API calls require Application-Name header as well as Application-Api-Key to be set and many others require Session-ID header. Here is how these headers are managed by SDK:

* Both Application-Name and Application-Api-Key are being set when initializng `RestContaxt`.
* Session-ID header is set upon `IUserApi.LoginAsync()` or `ISystemApi.LoginAdminAsync()` completion,
* Session-ID header gets removed upon `IUserApi.LogoutAsync()` or `ISystemApi.LogoutAdminAsync()` completion,
* Session-ID header gets updated if another login is made during `ChangePasswordAsync()` or `ChangeAdminPasswordAsync()` call.

To use/set another Application-Name and Application-Api-Key you have to instantiate new `RestContaxt`.

#### CustomSettings API

> See [ICustomSettingsApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/ICustomSettingsApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/CustomSettingsDemo.cs)

The API can be created for user and system namespace.

Custom settings are key value pairs, value being string type. Therefore if you wish to save a DTO as a setting you will have to serialize the DTO prior to creating `Custom Request` .
Please refer to the demo for sample API usage.

#### Files API

> See [IFilesApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/IFilesApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/FilesDemo.cs)

Summary on supported features:
* CRUD operations on folders and files,
* Bulk files uploading/downloading in ZIP format,
* Text and binary files reading/writing.

##### Notes on metadata support

Reading/Writing of metadata associated with file entities (folder, file) are not supported yet.

#### Database API

> See [IDatabaseApi](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory/Api/IDatabaseApi.cs) and [DEMO](https://github.com/dreamfactorysoftware/.net-sdk/blob/master/DreamFactory.Demo/Demo/DatabaseDemo.cs)

#### Notes on schema management

To simplify `TableSchema` construction, SDK offers `TableSchemaBuilder` class that implement Code First approach:
```csharp
	// Your custom POCO
	class StaffRecord
	{
		public int Uid { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
	}

	// Create tabe schema from StaffRecord type
	ITableSchemaBuilder builder = new TableSchemaBuilder();
	builder.WithName(TableName).WithFieldsFrom<StaffRecord>().WithKeyField("uid").Build();
```

For more advanced scenarios and relationship building you should build up your own TableSchema object.
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
* Some related entities are not retrieved (see related query parameter).
* Some related entities are retrieved as objects and are not strongly typed.
* Some related entities that are strongly typed do not have any properties.
