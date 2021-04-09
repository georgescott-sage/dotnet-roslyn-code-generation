using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_roslyn_code_generation.commands
{
    public class ClassBuilder
    {
        private ClassDeclarationSyntax classDeclaration;

        public ClassDeclarationSyntax Build() => classDeclaration;

        public ClassBuilder WithClass(string name, string baseType, Tuple<string, string>[] methodDeclarations, string summaryComment)
        {
            classDeclaration = SyntaxFactory.ClassDeclaration(name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseType)))
                .WithLeadingTrivia(new SyntaxTriviaList(new SyntaxTriviaList(SyntaxFactory.Comment("/// <summary>"), SyntaxFactory.Comment($"/// {summaryComment}"), SyntaxFactory.Comment("/// </summary>"))));

            return this;
        }

        public ClassBuilder WithMethods(string name, string baseType, Tuple<string, string>[] methodDeclarations, string summaryComment)
        {
            foreach(var method in methodDeclarations)
            {
                var creation = SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName(typeof(NotImplementedException).Name)).WithArgumentList(SyntaxFactory.ArgumentList());
                StatementSyntax notImplementedException = SyntaxFactory.ThrowStatement((ExpressionSyntax)creation);
                
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Item2), method.Item1)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithBody(SyntaxFactory.Block(notImplementedException));

                classDeclaration = classDeclaration.AddMembers(methodDeclaration);;
            }
            return this;
        }
    }
}
