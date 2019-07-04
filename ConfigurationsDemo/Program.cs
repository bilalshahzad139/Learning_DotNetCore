using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConfigurationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<String, String> inMemory = new Dictionary<string, string>();
            inMemory.Add("level", "100");

            //Create Builder Object
            var builder = new ConfigurationBuilder();

            //Set BasePath so it knows where to find files
            builder.SetBasePath(Directory.GetCurrentDirectory());

            //Add multiple configuration sources
            //The ones added late in this, take precedence
            builder
                .AddJsonFile("mysettings.json", true, true)
                .AddJsonFile("prod_settings.json", true, true)
                .AddXmlFile("test_settings.config", true, true)
                .AddInMemoryCollection(inMemory)
                //.AddEnvironmentVariables()  //It will include all Environment variables
                .AddEnvironmentVariables("MYAPP_") //It will include only those which are starting with MYAPP_ prefix
                .AddCommandLine(args);

            //IConfigurationRoot
            var configBuild = builder.Build();

            //Print all first level child
            foreach (var c in configBuild.GetChildren())
            {
                Console.WriteLine($"Key:{c.Key}, Value:{c.Value}, Path:{c.Path}");
            }

            //IConfigurationSection
            var dbsection = configBuild.GetSection("database");

            //Get a specific section
            Console.WriteLine("---------Children of database section");

            //Print all first level child (of this section)
            foreach (var c in dbsection.GetChildren())
            {
                Console.WriteLine($"Key:{c.Key}, Value:{c.Value}, Path:{c.Path}");
            }

            Console.WriteLine("--------------------------");
            //You can access an element by using flattend key
            Console.WriteLine($"DBName via key: {configBuild["database:dbname"]}");

            

            Console.ReadKey();
        }
    }
}
