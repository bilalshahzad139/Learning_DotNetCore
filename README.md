# DotNetCore

## Configurations Demo
### What are we going to learn?
- Load Configuration from Json file
- Load Configuration from XML file
- Load Configuration from In Memory
- Load Configuration from Environment Variables
- Load Configuration from Command Line Arguments
- Configuration Precedence

**Steps**
1) Create a .NET Core Console Application
2) Install following Packages
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.Xml
- Microsoft.Extensions.Configuration.EnvironmentVariables
- Microsoft.Extensions.Configuration.CommandLine

3) Add Two Json files (Right click on project -> Add -> New - Json File.
settings.json (Click on file and change "Copy to output Directory" => "Copy Always")
prod_settings.json (Click on file and change "Copy to output Directory" => "Copy Always")
4) Provide following configurations in JSON format

Here is content of first file (**settings.json**)

       {
          "cst": "testing12345",
          "level": "1",
          "database": {
            "dbname": "test",
            "userid": "sa",
            "password": "123"
          }
        }

and here is content of second file (**prod_settings.json**)

    {
      "database": {
        "dbname": "db_prod",
        "userid": "sa",
        "password": "12345"
      }
    }
5) Add New XML file (Right click on project -> Add -> New - App configuration (i.e. test_settings.config). (Click on file and change "Copy to output Directory" => "Copy Always")
6) Add following content in XML file
First line should be following     
> <?xml version="1.0" encoding="utf-8" ?>
Other content is

    <root>
      <level>5</level>
      <database>
        <dbname>test2</dbname>
        <userid>sa2</userid>
        <password>12345</password>
      </database>
    </root>

7) Check & add Code from program.cs file
8) You may now run & build the application to check output or you may go the folder which project (.csproj) exists and Open CMD there
To build & run the application
> dotnet run 

To Pass arguments
> dotnet run --level=3

To create an environment variable
> SET MYAPP_DATA=3

## DependencyInjection DEMO
In demo (Video), We've learnt what is Dependency Injection and what happens if we don't follow DI principal. Then we saw, what is IoC Container (a framework for implementing automatic dependency injection. It manages object creation and it's life-time, and also injects dependencies to the class).

.NET Core provides built-in IoC Container

**Agenda**
- Why do we Need Dependency Injection
- Example with DI 
- What is IoC Container
- Using Builtin IoC Container in .NET Core
[For More details:](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2#service-lifetimes-and-registration-options)

----

## LoggingDEMO
In this demo, We've discussed New Logging Framework Provided by .NET Core. We've learnt
- What is new Logging Framework in .NET Core? => Microsoft.Extensions.Logging
- What is a Logging Provider? => Example: Microsoft.Extensions.Logging
-- These provide Extension Methods to Register with DI (e.g. AddConsole())
- How to use Logger with DI Framework
- How to use ILoggerFactory to Create Logger Instance
- How to filter Log Messages by Log Levels => AddFilter
- How to use Configuration with Logging
- How to use Logger in a different class (e.g. Get Logger from DI)
- Example of another Provider (NLog)

----
## Middleware Basics DEMO
In this demo, we've created an Empty ASP.NET Core Project and discussed following pionts
- What is a middleware
- Run, Map, Map*, Use functions
- next() delegate
- Creating a new Middleware
- Injecting ILogger Dependency 

