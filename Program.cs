using System;
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
            var command = commandCreator.CreateInterface(new CommandDefinition());

            Console.WriteLine(command);

            // Wait to exit.
            Console.Read();
        }
    }
}
