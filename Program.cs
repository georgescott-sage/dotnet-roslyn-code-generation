using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace dotnet_roslyn_code_generation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create a command interface
            CreateCommandInterface();

            // Wait to exit.
            Console.Read();
        }

        private static void CreateCommandInterface()
        {
            // Create a namespace: (namespace CodeGenerationSample)
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("projectnamespacecore")).NormalizeWhitespace();

             // Add System using statement: (using System)
            @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")));

            //  Create a class: (get uses command interface)
            var interfaceDefinition = SyntaxFactory.InterfaceDeclaration("IGetUsersCommand");

            interfaceDefinition = interfaceDefinition.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            // Create a stament with the body of a method.
            var syntax = SyntaxFactory.ParseStatement("canceled = true;");

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(interfaceDefinition);

            // Normalize and get code as string.
            var code = @namespace
                .NormalizeWhitespace()
                .ToFullString();

            // Output new code to the console.
            Console.WriteLine(code);
        }
    }
}
