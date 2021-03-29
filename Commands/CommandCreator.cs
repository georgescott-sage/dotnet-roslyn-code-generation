using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using dotnet_roslyn_code_generation.commands.definitions;
namespace dotnet_roslyn_code_generation.commands
{
    public interface ICommandCreator
    {
        string CreateInterface(InterfaceDefinition interfaceDefinition);
    }

    public class CommandCreator : ICommandCreator
    {
        public string CreateInterface(InterfaceDefinition interfaceDefinition)
        {
             // Create a namespace: (namespace CodeGenerationSample)
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(interfaceDefinition.Namespace())).NormalizeWhitespace();

             // Add System using statement: (using System)
            @namespace = @namespace.AddUsings(
                interfaceDefinition.Usings().Select(
                    x => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(x))
                    ).ToArray()
                );

            //  Create a class: (get uses command interface)
            var definition = SyntaxFactory.InterfaceDeclaration(interfaceDefinition.Name())
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(interfaceDefinition.BaseType())));

            foreach(var method in interfaceDefinition.MethodDeclarations())
            {
                // Create a method
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Value.Name), method.Key)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                // Add the field, the property and method to the class.
                definition = definition.AddMembers(methodDeclaration);
            }

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(definition);

            // Normalize and get code as string.
            return @namespace
                .NormalizeWhitespace()
                .ToFullString();
        }
    }
}
