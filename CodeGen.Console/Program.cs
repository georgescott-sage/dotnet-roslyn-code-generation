using System;
using System.Collections.Generic;
using codegen.library.definitions;
using codegen.library.builders;
using Microsoft.Extensions.DependencyInjection;

namespace code_gen.console
{
    class Program
    {
        static void Main(string[] args)
        {
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
