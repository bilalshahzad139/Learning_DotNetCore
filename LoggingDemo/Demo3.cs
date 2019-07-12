/*Step 2 - Add Namespaces
 * ----------*/
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
/*-------------------*/

using System;
using System.IO;

namespace LoggingDemo
{
    /* Objective: Learning AddConfiguration Method*/

    public static class Demo3
    {
        public static void SetupTest()
        {
            //Build Configuration Object
            var configurationObj = GetConfiguration();

            //Step 3: Create ServiceCollection Object
            var serviceCollection = new ServiceCollection();

            //----------------------------------------------------
            //Step 4: Configure Dependencies/Services
            serviceCollection.AddLogging(builder => builder
                                .AddConsole()
                                .AddConfiguration(configurationObj.GetSection("Logging")) //Set Logging related settings
            );
            


            //Step 5: Get serviceProvider to use later to get services/instances
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //We need to Provide Category. We may pass Our class as T to ILogger
            ILogger logger = serviceProvider.GetService<ILogger<Program>>();
            logger.Log(LogLevel.Information, "Learning In Urdu!");
            logger.LogInformation("Learning In Urdu!");
            logger.LogError("Learning In Urdu!");
            logger.LogWarning("Learning In Urdu!");

        }

        public static IConfigurationRoot GetConfiguration()
        {
            #region Configuration Builder
            //Create Builder Object
            var builder = new ConfigurationBuilder();

            //Set BasePath so it knows where to find files
            builder.SetBasePath(Directory.GetCurrentDirectory());

            //Add multiple configuration sources
            builder
                .AddJsonFile("mysettings.json", true, true);

            //IConfigurationRoot
            var configBuild = builder.Build();

            return configBuild;
            #endregion
        }
    }
}
