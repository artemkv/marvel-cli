# Marvel Command Line Tool

Command line tool to provide an interface to the marvel-server.

## Design

The tool is a thin wrapper on top of marvel server API.
It does not provide any validation logic and simply passes the parameters to the API.

### Main components

* __SDK or client library (namespace marvel.sdk):__ - Knows how to speak to Marvel server. Exposes all the data through the MarvelApi class, which serves as a facade for the client library, hiding protocol details.
* __Command-line parsing and printout logic (namespace marvel):__ - Converts command-line arguments into MarvelApi method parameters and prints the returned results to the console.

## Build and run the project

This is .Net Core console application.

Run to build for Windows:

```
dotnet publish -r win-x64 -c release
```

The build output can be found in __marvel\bin\Release\netcoreapp2.1\win-x64\publish__

Run to build for Linux:

```
dotnet publish -r linux-x64 -c release
```

The build output can be found in __marvel\bin\Release\netcoreapp2.1\linux-x64\publish__

## Dependencies

* .Net Core 2.1
* CommandLineParser (Command Line Parser Library)
* Newtonsoft.Json (A popular high-performance JSON framework for .NET)

## Command line arguments

Run "marvel" without arguments or "marvel help" to see the available commands.

```
marvel help
```

Run "marvel help &lt;command&gt;" to the command-specific help.

```
marvel help find
```

### Commands

* __help__ - Prints the help.
* __version__ - Prints the version info.
* __find__ - Finds the creator by id.
* __list__ - Shows the lists of creators with sorting and paging.
* __addnote__ - Adds a note to a creator. If note already exists, overwrites it.
* __deletenote__ - Deletes a note for a creator.

### Examples

For detailed help on command line options, use the tool built-in help. Below some quick examples on tool usage:

```
marvel list
marvel list --url http://192.168.1.8:8080/
marvel list --page 3 --size 5
marvel list --n --page 3 --size 5
marvel list --fullname "rick"
marvel list --modifiedsince "09/06/2015 17:20:52"
marvel list --modifiedsince "2015-01-01 00:00:00"
marvel list --modifiedsince "2015-01-01 00:00:00" --page 3 --size 5
marvel list --fullname "rick" --modifiedsince "09/06/2015 17:20:51"
marvel list --page 3 --size 5 --sortby comicsTotal,desc fullName
marvel find --id 12976 --n
marvel addnote --c 12976 --text "Hello note"
marvel deletenote --c 12976
```
