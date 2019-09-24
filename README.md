<p align="center"><img src="dot-net-core.svg" height="200" width="300" alt="header-image"></p>
<h1 align="center"> Learning .NET Core </h1>

<p align="center"
  <a href="https://www.youtube.com/channel/UCk1JI7ASy1EnzaM0hdVcuAQ">
  <img src="https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square" alt="PRs Welcome">
  </a>
</p>

## Welcome

The goal of this learning project is to enable .NET programmers to learn the new .NET Core stack from the ground up directly from code. You can get the demo video resources on [Youtube Channel - Learn in Urdu](https://www.youtube.com/playlist?list=PL0kdOcU3HXGLoOF5Grh-C7FMJC3gju5Q9)

## Configurations Demo

### Agenda for Configurations

- Load Configuration from Json file
- Load Configuration from XML file
- Load Configuration from In Memory
- Load Configuration from Environment Variables
- Load Configuration from Command Line Arguments
- Configuration Precedence
- [Youtube Link](https://www.youtube.com/watch?v=rfvgFGBIuls) - Configurations Demo Video  

  **STEPS**

- Create a .NET Core Console Application

- Install following Packages

  * Microsoft.Extensions.Configuration
  * Microsoft.Extensions.Configuration.Json
  * Microsoft.Extensions.Configuration.Xml
  * Microsoft.Extensions.Configuration.EnvironmentVariables
  * Microsoft.Extensions.Configuration.CommandLine

- Add Two Json files

  * Right click on project -> Add -> New - Json File
  * *settings.json* (Click on file and change "Copy to output Directory" => "Copy Always")
  * *prod_settings.json* (Click on file and change "Copy to output Directory" => "Copy Always")

- Provide following configurations in JSON format

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

- Add New XML file

  * Right click on project -> Add -> New -> App configuration (i.e. test_settings.config)
  * Click on file and change "Copy to output Directory" => "Copy Always"

- Add following content in XML file

  ```
  <?xml version="1.0" encoding="utf-8" ?>

  <root>
    <level>5</level>
    <database>
      <dbname>test2</dbname>
      <userid>sa2</userid>
      <password>12345</password>
    </database>
  </root>

  ```

- Check &amp; add Code from *Program.cs* file
- You may now run & build the application to check output or you may go the folder which project (*.csproj*) exists and Open *CMD* there

  Build & Run the application
  > dotnet run
  
  To Pass arguments
  > dotnet run --level=3

  To create an environment variable
  > SET MYAPP_DATA=3

----

## DependencyInjection DEMO

In demo ([Video](https://www.youtube.com/watch?v=rfvgFGBIuls)), We learnt what is **`Dependency Injection`** and what happens if we don't follow **`DI principal`**. Then we learnt about, what is **`IoC Container`** (a framework for implementing automatic dependency injection

- Purpose of IoC Container

   * It manages object creation and it's life-time
   * It injects dependencies to the class
   * .NET Core provides built-in IoC Container

### Agenda for DI

- Why do we Need Dependency Injection
- Example with DI
- What is IoC Container
- Using Builtin IoC Container in .NET Core
- [Youtube Link](https://www.youtube.com/watch?v=rfvgFGBIuls) - Dependency Injection Demo Video

[For More details:](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2#service-lifetimes-and-registration-options) - Microsoft Official Docs

----

## LoggingDEMO

In this demo, We've discussed New Logging Framework Provided by .NET Core.

### Agenda for Logging

- What is new Logging Framework in .NET Core? => *Microsoft.Extensions.Logging*
- What is a Logging Provider? => Example: Microsoft.Extensions.Logging - These provide Extension Methods to Register with DI (e.g. AddConsole())
- How to use Logger with DI Framework
- How to use **`ILoggerFactory`** to Create Logger Instance
- How to filter Log Messages by Log Levels => AddFilter
- How to use Configuration with Logging
- How to use Logger in a different class (e.g. Get Logger from DI)
- Example of another Provider (**NLog**)
- [Youtube Link](https://www.youtube.com/watch?v=Em_eG7g0R2o) - Dependency Injection Demo Video

----

## Middleware Basics DEMO

In this demo, We created an Empty ASP.NET Core Project and discussed following pionts

- What is a Middleware
- Run, Map, Map*, Use functions
- next() delegate
- Creating a new Middleware
- Injecting ILogger Dependency
- [Youtube Link](https://www.youtube.com/watch?v=OITKViJuqIs) - Middleware Basic Demo Video  

<br/>

[:arrow_up: Back to top](#-learning-net-core-)
