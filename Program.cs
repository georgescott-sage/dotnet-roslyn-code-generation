using System;
using dotnet_roslyn_code_generation.builders;
using dotnet_roslyn_code_generation.commands;
using dotnet_roslyn_code_generation.commands.definitions;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_roslyn_code_generation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICommandCreator, CommandCreator>()
                .BuildServiceProvider();

            var commandCreator = serviceProvider.GetService<ICommandCreator>();

            // Create a command interface
            var generatedCommandInterface = commandCreator.CreateInterface(new CommandInterfaceDefinition());
            Console.WriteLine("generatedCommandInterface:");
            Console.WriteLine(generatedCommandInterface);
            Console.WriteLine();

            // Create a command
            var generatedCommand = commandCreator.CreateClass(new CommandDefinition());
            Console.WriteLine("generatedCommand:");
            Console.WriteLine(generatedCommand);

            // Wait to exit.
            Console.Read();
        }
    }
}
