using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_roslyn_code_generation.builders
{
    public class ClassBuilder : AbstractTypeBuilder
    {
        public override TypeDeclarationSyntax Build() => (ClassDeclarationSyntax) typeDeclaration;

        public override AbstractTypeBuilder WithDefinition(string name, string baseType)
        {
            typeDeclaration = SyntaxFactory.ClassDeclaration(name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseType)));

            return this;
        }

        public override AbstractTypeBuilder WithMethodDeclarations(Tuple<string, string>[] methodDeclarations)
        {
            foreach(var method in methodDeclarations)
            {
                var creation = SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName(typeof(NotImplementedException).Name)).WithArgumentList(SyntaxFactory.ArgumentList());
                StatementSyntax notImplementedException = SyntaxFactory.ThrowStatement((ExpressionSyntax)creation);
                
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Item2), method.Item1)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithBody(SyntaxFactory.Block(notImplementedException));

                typeDeclaration = typeDeclaration.AddMembers(methodDeclaration);
            }
            return this;
        }
    }
}
