using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo
{
    //For More details: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2#service-lifetimes-and-registration-options

    //For source code: https://github.com/bilalshahzad139/Learning_DotNetCore

    //For Other Tutorials: http://LearningInUrdu.pk
    class Program
    {
        /* Agenda */
        //------------------------------
        // Need of Dependency Injection
        // Example with DI 
        // What is IoC Container
        // Using Builtin IoC Container in .NET Core
        // Quick Overview of Builtin Services in ASP.NET Core
        static void Main(string[] args)
        {
            //-------------Without Dependency Injection

            //Consumer obj = new Consumer();
            //obj.ConsumeThings();
            //System.Console.ReadKey();


            #region With Dependency Injection but without IoC Container
            //-------------With Dependency Injection but without IoC Container
            
            //IMyDependency depObj = new MyDependency();
            //Consumer obj = new Consumer(depObj);
            //obj.ConsumeThings();
            
            #endregion

            #region What is IoC Container? 
            /* What is IoC Container? 
             * -------------------
             * IoC Container is a framework for implementing 
             * automatic dependency injection. It manages 
             * object creation and it's life-time, 
             * and also injects dependencies to the class.
             * Examples: Unity, StructureMap. NInject
             */

            //.NET Core Provides a builtin IoC Container
            #endregion

            #region Using .NET Core DI Framework
            //Step 1: Add Package => Microsoft.Extensions.DependencyInjection
            //Step 2: Add Namespace Microsoft.Extensions.DependencyInjection;
            //Step 3: Create ServericeCollection
            var serviceCollection = new ServiceCollection();

            //Step 4: Registration

            /* Singleton: One instance for whole life cycle of application
             * Scoped: One for life cycle of whole Request (e.g. Web Request)
             * Transient: New instance whenever injected to a class
             */

            serviceCollection.AddScoped<IMyDependency, MyDependency>();//serviceCollection.AddScoped(typeof(IMyDependency), typeof(MyDependency));
            serviceCollection.AddSingleton<IEmailSender, MyEmailSender>();
            serviceCollection.AddTransient<Consumer>();

            //We may also move above registration code to a function
            //ConfigureServices(serviceCollection);

            //Step 5: Resolve (Get Instance)
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Here it will create instance of relevant dependencies (Consumer depends on) and will create instance of consumer using those

            var objConsumer = serviceProvider.GetService<Consumer>();
            objConsumer.ConsumeThings();
            #endregion

            System.Console.ReadKey();
        }

        /*
        //Step 4: Registration
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency>();//serviceCollection.AddScoped(typeof(IMyDependency), typeof(MyDependency));
            services.AddSingleton<IEmailSender, MyEmailSender>();
            services.AddTransient<Consumer>();
        }
        */
    }
}
