using DebendencyContainer;
using System;

namespace assemblyloadtest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (new MethodManager().GetResult())
                {
                    Console.WriteLine("Evrithing OK.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Huston we have a problem: " + e.Message);
            }
        }
    }
}
