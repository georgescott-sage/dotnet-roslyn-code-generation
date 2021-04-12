using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_roslyn_code_generation.commands
{
    public class InterfaceBuilder
    {
        private InterfaceDeclarationSyntax interfaceDeclaration;

        public InterfaceDeclarationSyntax Build() => interfaceDeclaration;

        public InterfaceBuilder WithInterface(string name, string baseType, Tuple<string, string>[] methodDeclarations, string summaryComment)
        {
            interfaceDeclaration = SyntaxFactory.InterfaceDeclaration(name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseType)))
                .WithLeadingTrivia(new SyntaxTriviaList(new SyntaxTriviaList(SyntaxFactory.Comment("/// <summary>"), SyntaxFactory.Comment($"/// {summaryComment}"), SyntaxFactory.Comment("/// </summary>"))));
            return this;
        }

        public InterfaceBuilder WithMethodDeclarations(Tuple<string, string>[] methodDeclarations)
        {
            foreach(var method in methodDeclarations)
            {
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Item2), method.Item1)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                interfaceDeclaration = interfaceDeclaration.AddMembers(methodDeclaration);
            }
            return this;
        }
    }
}
