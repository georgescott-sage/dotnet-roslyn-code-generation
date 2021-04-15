using System;
using System.Collections.Generic;
using dotnet_roslyn_code_generation.builders;
using dotnet_roslyn_code_generation.commands;
using dotnet_roslyn_code_generation.commands.definitions;
using dotnet_roslyn_code_generation.SampleEndpointDocs;
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

            var endpoint = new EndpointDetail()
            {
                Description = "Retrieve a role.",
                HttpAction = "Get",
                Path = "/v1/roles/{RoleId}",
                Resource = "Role",
                PathParameters = new List<PathParameter>()
                {
                    new PathParameter()
                    {
                        Name = "RoleId",
                        Type = "string",
                        Format = "uuid",
                        Required = true,
                        Description = "Unique ID of the role."
                    }
                }
            };

             // Create a query interface
            var generatedQueryInterface = commandCreator.CreateInterface(new QueryInterfaceDefinition(endpoint));
            Console.WriteLine("generatedQueryInterface:");
            Console.WriteLine(generatedQueryInterface);
            Console.WriteLine();

            // Create a command interface
            var generatedCommandInterface = commandCreator.CreateInterface(new CommandInterfaceDefinition(endpoint));
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
