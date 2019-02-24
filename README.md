# Marvel Command Line Tool

Command line tool to provide an interface to the marvel-server.

## Design

The tool is a thin wrapper on top of marvel server API.
It does not provide any validation logic and simply passes the parameters to the API.

### Main components

* __SDK or client library (namespace marvel.sdk):__ - Knows how to speak to Marvel server. Exposes all the data through the MarvelApi class, which serves as a facade for the client library, hiding protocol details.
* __Command-line parsing and printout logic (namespace marvel):__ - Converts command-line arguments into MarvelApi method parameters and prints the returned results to the console.

## Build and run the project

Run to build for Windows:

```
dotnet publish -r win-x64 -c release
```

The build output can be found in \marvel\bin\Release\netcoreapp2.1\win-x64\publish

Run to build for Linux:

```
dotnet publish -r linux-x64 -c release
```

The build output can be found in \marvel\bin\Release\netcoreapp2.1\linux-x64\publish

## Dependencies

* .Net Core 2.1
* CommandLineParser (Command Line Parser Library)
* Newtonsoft.Json (A popular high-performance JSON framework for .NET)

## Command line arguments
