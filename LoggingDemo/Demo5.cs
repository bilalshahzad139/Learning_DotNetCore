/*Step 2 - Add Namespaces
 * ----------*/
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web; //For ConfigureNLog
/*-------------------*/


using System;

namespace LoggingDemo
{
    /* Objective: Including NLog as another Logging Provider*/
    //https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-2
    public static class Demo5
    {
        public static void SetupTest()
        {
            //Step 3: Create ServiceCollection Object
            var serviceCollection = new ServiceCollection();

            //----------------------------------------------------
            //Step 4: Configure Dependencies/Services
            serviceCollection.AddLogging(builder => builder
                                                 .AddConsole()
                                                .ConfigureNLog("nlog.config")
            );
            serviceCollection.AddTransient<DemoTest3>();

            //Step 5: Get serviceProvider to use later to get services/instances
            var serviceProvider = serviceCollection.BuildServiceProvider();


            //Create Instance of Your class through IoC Container so It will 'inject' required dependencies
            var obj1 = serviceProvider.GetService<DemoTest3>();
            obj1.TestMethod();

        }
    }


    public class DemoTest3
    {
        private readonly ILogger _logger;
        public DemoTest3(ILogger<DemoTest3> logger)
        {
            _logger = logger;
        }

        public void TestMethod()
        {
            _logger.LogInformation("Learning In Urdu!");
        }
    }
    
}
