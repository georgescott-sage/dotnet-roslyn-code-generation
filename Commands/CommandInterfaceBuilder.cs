using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Collections.Generic;
using System;
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
                    x => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(x))
                    ).ToArray()
                );
            return this;
        }

        public CommandInterfaceBuilder WithInterface(string name, string baseType, Tuple<string, string>[] methodDeclarations, string summaryComment)
        {
            var definition = SyntaxFactory.InterfaceDeclaration(name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseType)))
                .WithLeadingTrivia(new SyntaxTriviaList(new SyntaxTriviaList(SyntaxFactory.Comment("/// <summary>"), SyntaxFactory.Comment($"/// {summaryComment}"), SyntaxFactory.Comment("/// </summary>"))));

            foreach(var method in methodDeclarations)
            {
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Item2), method.Item1)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                definition = definition.AddMembers(methodDeclaration);
            }

            namespaceDeclaration = namespaceDeclaration.AddMembers(definition);

            return this;
        }

        public CommandInterfaceBuilder WithClass(string name, string baseType, Tuple<string, string>[] methodDeclarations, string summaryComment)
        {
            var definition = SyntaxFactory.ClassDeclaration(name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseType)))
                .WithLeadingTrivia(new SyntaxTriviaList(new SyntaxTriviaList(SyntaxFactory.Comment("/// <summary>"), SyntaxFactory.Comment($"/// {summaryComment}"), SyntaxFactory.Comment("/// </summary>"))));

            foreach(var method in methodDeclarations)
            {
                var creation = SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName(typeof(NotImplementedException).Name)).WithArgumentList(SyntaxFactory.ArgumentList());
                StatementSyntax notImplementedException = SyntaxFactory.ThrowStatement((ExpressionSyntax)creation);
                
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Item2), method.Item1)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithBody(SyntaxFactory.Block(notImplementedException));

                definition = definition.AddMembers(methodDeclaration);
            }

            namespaceDeclaration = namespaceDeclaration.AddMembers(definition);

            return this;
        }
    }
}
