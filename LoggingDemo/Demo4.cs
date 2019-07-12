/*Step 2 - Add Namespaces
 * ----------*/
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
/*-------------------*/

using System;


namespace LoggingDemo
{
    /* Objective: Learning how to use Logger in different class through IoC*/

    public static class Demo4
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
            serviceCollection.AddTransient<DemoTest1>();
            serviceCollection.AddTransient<DemoTest2>();


            //Step 5: Get serviceProvider to use later to get services/instances
            var serviceProvider = serviceCollection.BuildServiceProvider();


            //Create Instance of Your class through IoC Container so It will 'inject' required dependencies
            var obj1 = serviceProvider.GetService<DemoTest1>();
            obj1.TestMethod();


            //Create Instance of Your class through IoC Container so It will 'inject' required dependencies
            var obj2 = serviceProvider.GetService<DemoTest2>();
            obj2.TestMethod();

        }
    }




    public class DemoTest1
    {
        private readonly ILogger _logger;
        public DemoTest1(ILogger<DemoTest1> logger)
        {
            _logger = logger;
        }

        public void TestMethod()
        {
            _logger.LogInformation("Learning In Urdu!");
        }
    }

    public class DemoTest2
    {
        private readonly ILogger _logger;
        public DemoTest2(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("DemoTest2");
        }
        public void TestMethod()
        {
            try
            {
                throw new Exception("Exception Logging Test");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception has occurred");
            }
        }
    }
}
