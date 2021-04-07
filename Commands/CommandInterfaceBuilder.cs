using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.CodeAnalysis;

namespace dotnet_roslyn_code_generation.commands
{
    public class CommandInterfaceBuilder
    {
        private Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax namespaceDeclaration;

        public string Build() => namespaceDeclaration
            .NormalizeWhitespace()
            .ToFullString();
        
        //should be init?
        public CommandInterfaceBuilder WithNamespace(string name)
        {
            namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(name));
            return this;
        }

        public CommandInterfaceBuilder WithUsings(IEnumerable<string> usings)
        {
            namespaceDeclaration = namespaceDeclaration.AddUsings(
                usings.Select(
                    x => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(x))
                    ).ToArray()
                );
            return this;
        }

        public CommandInterfaceBuilder WithInterface(string name, string baseType, Tuple<string, Type>[] methodDeclarations)
        {
            var definition = SyntaxFactory.InterfaceDeclaration(name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseType)));

            foreach(var method in methodDeclarations)
            {
                // Create a method
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Item2.Name), method.Item1)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                // Add the field, the property and method to the class.
                definition = definition.AddMembers(methodDeclaration);
            }

            namespaceDeclaration = namespaceDeclaration.AddMembers(definition);
            return this;
        }

    }
}
