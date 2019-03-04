using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DebendencyContainer
{
    public class Resolver
    {
        public static IConfiguration executorconfig { get; set; }
        static string myappname = Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName);

        static Resolver()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("Configuration.json");
            builder.AddJsonFile($"Configuration.{myappname}.json", optional: true);
            executorconfig = builder.Build();
        }

        public static IMethods GetMethod(Type methodType)
        {
            try
            {
                string executingAssemblyPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
                string assemblyPath = Path.Combine(executingAssemblyPath, executorconfig["Methods:" + methodType.ToString() + ":Assembly"]);
                Assembly assembly = Assembly.LoadFile(assemblyPath);

                Type objtype = assembly.GetType(executorconfig["Methods:" + methodType.ToString() + ":class"]);
                var handlerInstance = Activator.CreateInstance(objtype);
                return (IMethods)handlerInstance;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by resolving: " + ex.Message);
                return null;
            }
        }

    }
}
