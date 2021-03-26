using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using dotnet_roslyn_code_generation.commands;

namespace dotnet_roslyn_code_generation.commands
{
    public interface ICommandCreator
    {
        string CreateCommandInterface();
    }

    public class CommandCreator : ICommandCreator
    {
        public string CreateCommandInterface()
        {
            // Create a namespace: (namespace CodeGenerationSample)
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("projectnamespacecore")).NormalizeWhitespace();

             // Add System using statement: (using System)
            @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")));

            //  Create a class: (get uses command interface)
            var interfaceDefinition = SyntaxFactory.InterfaceDeclaration("IGetUsersCommand")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("ICustomCommand<UpdateBusinessHealthCommandRequest, UpdateBusinessHealthCommandResponse>")));

            // Create a method
            var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("void"), "MarkAsCanceled")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            // Add the field, the property and method to the class.
            interfaceDefinition = interfaceDefinition.AddMembers(methodDeclaration);

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(interfaceDefinition);

            // Normalize and get code as string.
            return @namespace
                .NormalizeWhitespace()
                .ToFullString();
        }
    }
}
