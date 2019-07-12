/*Step 2 - Add Namespaces
 * ----------*/
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
/*-------------------*/

using System;


namespace LoggingDemo
{
    /* Objective: Learning Basics of .NET Core Logging Framework with Console Logging Provider*/
    //AddConsole() //https://github.com/aspnet/Logging/blob/release/2.2/src/Microsoft.Extensions.Logging.Console/ConsoleLoggerFactoryExtensions.cs

    public static class Demo1
    {
        public static void SetupTest()
        {
            //Step 3: Create ServiceCollection Object
            var serviceCollection = new ServiceCollection();

            //----------------------------------------------------
            //Step 4: Configure Dependencies/Services
            serviceCollection.AddLogging(builder => builder
                                .AddConsole()  
            );

            //Step 5: Get serviceProvider to use later to get services/instances
            var serviceProvider = serviceCollection.BuildServiceProvider();


            //We need to Provide Category. We may pass Our class as T to ILogger
            ILogger logger = serviceProvider.GetService<ILogger<Program>>();
            logger.Log(LogLevel.Information, "Learning In Urdu!");
            logger.LogInformation("Learning In Urdu!");
            logger.LogError("Learning In Urdu!");
            logger.LogWarning("Learning In Urdu!");


            //Templating
            var id = 100;
            logger.LogInformation("Learning In Urdu! {id}", id);


            //Or We can use ILoggerFactory and create Logger by Providing Category as String
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger2 = loggerFactory.CreateLogger("LoggingDemo.Program");
            logger2.LogInformation("Testing1234");

        }
    }
}
