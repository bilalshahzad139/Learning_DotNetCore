using System;

namespace LoggingDemo
{
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2

    /*Objective: 
             * 1) What is new Logging Framework in .NET Core? => Microsoft.Extensions.Logging
             * 2) What is a Logging Provider? => Example: Microsoft.Extensions.Logging
             *  a) These provide Extension Methods to Register with DI (e.g. AddConsole())
             * 3) How to use Logger with DI Framework
             * 4) How to use ILoggerFactory to Create Logger Instance
             * 5) How to filter Log Messages by Log Levels => AddFilter
             * 6) How to use Configuration with Logging
             * 7) How to use Logger in a different class (e.g. Get Logger from DI)
             * 8) Example of another Provider (NLog)
    */

    class Program
    {
        static void Main(string[] args)
        {
            /* Step 1: Add NuGet Packages 
             * -----------------
             * Add Logging Framework => Microsoft.Extensions.Logging
             * Add DI Framework => Microsoft.Extensions.DependencyInjection
             * Add Console Log Provider => Microsoft.Extensions.Logging.Console
             * -------------
             */

            /* ----For Configuration Demo------, Add following packages
             * Microsoft.Extensions.Configuration
             * Microsoft.Extensions.Configuration.Json
             */

            /* ----For NLog Demo------, Add following packages
             * NLog.Web.AspNetCore
             * NLog
             */


            Demo1.SetupTest(); //Basic Logging Understanding
            //Demo2.SetupTest(); //AddFilter Method
            //Demo3.SetupTest(); //AddConfiguration Method
            //Demo4.SetupTest(); //Using with Custom Classes
            //Demo5.SetupTest(); //NLog Demo

            Console.ReadKey();
        }
    }
}
