using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_roslyn_code_generation.commands
{

    public class CommandInterfaceBuilder
    {
        private Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax namespaceDeclaration;

        public string Build() => namespaceDeclaration
            .NormalizeWhitespace()
            .ToFullString();
        
        public CommandInterfaceBuilder WithNamespace(string name)
        {
            namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(name));
            return this;
        }

        public CommandInterfaceBuilder WithReferences(IEnumerable<string> references)
        {
            namespaceDeclaration = namespaceDeclaration.AddUsings(
                references.Select(
                    x => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(x))).ToArray()
                );
            return this;
        }

        public CommandInterfaceBuilder WithClass(ClassDeclarationSyntax classDefinition)
        {
            namespaceDeclaration = namespaceDeclaration.AddMembers(classDefinition);

            return this;
        }

        public CommandInterfaceBuilder WithInterface(InterfaceDeclarationSyntax interfaceDeclaration)
        {
            namespaceDeclaration = namespaceDeclaration.AddMembers(interfaceDeclaration);

            return this;
        }


    }
}
