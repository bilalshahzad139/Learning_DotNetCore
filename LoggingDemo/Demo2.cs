/*Step 2 - Add Namespaces
 * ----------*/
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
/*-------------------*/

using System;


namespace LoggingDemo
{
    /* Objective: Learning AddFilter Method*/

    public static class Demo2
    {
        public static void SetupTest()
        {
            //Step 3: Create ServiceCollection Object
            var serviceCollection = new ServiceCollection();

            //----------------------------------------------------
            //Step 4: Configure Dependencies/Services
            serviceCollection.AddLogging(builder => builder
                                .AddConsole()
                                .AddFilter(level => level >= LogLevel.Error) //Supress log messages lower than this one
            );

            /*
              Trace = 0,
              Debug = 1,
              Information = 2,
              Warning = 3,
              Error = 4,
              Critical = 5,
              None = 6
            */


            //Step 5: Get serviceProvider to use later to get services/instances
            var serviceProvider = serviceCollection.BuildServiceProvider();


            //We need to Provide Category. We may pass Our class as T to ILogger
            ILogger logger = serviceProvider.GetService<ILogger<Program>>();
            logger.Log(LogLevel.Information, "Learning In Urdu!");
            logger.LogInformation("Learning In Urdu!");
            logger.LogError("Learning In Urdu!");
            logger.LogWarning("Learning In Urdu!");

        }
    }
}
