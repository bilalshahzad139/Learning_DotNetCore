using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo
{
    /* Reference Links
     * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2#service-lifetimes-and-registration-options
     */

    class Program
    {
        static void Main(string[] args)
        {
            //-------------Without Dependency Injection
            /*
            Consumer obj = new Consumer();
            obj.ConsumeThings();
            System.Console.ReadKey();
            */

            //-------------With Dependency Injection but withou IoC Container
            /*
            IMyDependency depObj = new MyDependency();
            Consumer obj = new Consumer(depObj);
            obj.ConsumeThings();
            */


            /* What is IoC Container? 
             * -------------------
             * IoC Container is a framework for implementing 
             * automatic dependency injection. It manages 
             * object creation and it's life-time, 
             * and also injects dependencies to the class.
             * Examples: Unity, StructureMap. NInject
             */

            //.NET Core Provides a builtin IoC Container
            
            //Step 1: Add Package => Microsoft.Extensions.DependencyInjection
            //Step 2: Add Namespace Microsoft.Extensions.DependencyInjection;
            //Step 3: Create ServericeCollection
            var serviceCollection = new ServiceCollection();

            //Step 4: Registration
            ConfigureServices(serviceCollection);
            /*
            serviceCollection.AddScoped<IMyDependency, MyDependency>();//serviceCollection.AddScoped(typeof(IMyDependency), typeof(MyDependency));
            //serviceCollection.AddSingleton(typeof(IMyDependency), typeof(MyDependency2));
            serviceCollection.AddTransient<Consumer>();
            */

            //Step 5: Resolve (Get Instance)
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Here it will create instance of relevant dependencies (Consumer depends on) and will create instance of consumer using those
            var objConsumer = serviceProvider.GetService<Consumer>();

            objConsumer.ConsumeThings();


            System.Console.ReadKey();
        }


        //Step 4: Registration
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency>();//serviceCollection.AddScoped(typeof(IMyDependency), typeof(MyDependency));
            //services.AddSingleton(typeof(IMyDependency), typeof(MyDependency));
            services.AddTransient<Consumer>();
        }
    }
}
