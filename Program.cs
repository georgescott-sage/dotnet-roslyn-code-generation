using System;
using dotnet_roslyn_code_generation.commands;

namespace dotnet_roslyn_code_generation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create a command interface
            CommandCreator.CreateCommandInterface();

            // Wait to exit.
            Console.Read();
        }
    }
}
