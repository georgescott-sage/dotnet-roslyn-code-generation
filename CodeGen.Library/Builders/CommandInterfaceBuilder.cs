using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace codegen.library.builders
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

        public CommandInterfaceBuilder WithClass(TypeDeclarationSyntax classDefinition)
        {
            namespaceDeclaration = namespaceDeclaration.AddMembers((ClassDeclarationSyntax) classDefinition);
            return this;
        }

        public CommandInterfaceBuilder WithInterface(TypeDeclarationSyntax interfaceDeclaration)
        {
            namespaceDeclaration = namespaceDeclaration.AddMembers((InterfaceDeclarationSyntax) interfaceDeclaration);
            return this;
        }
    }
}
