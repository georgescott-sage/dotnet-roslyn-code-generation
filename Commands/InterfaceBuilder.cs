using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_roslyn_code_generation.commands
{

    public class InterfaceBuilder : AbstractTypeBuilder
    {
        public override TypeDeclarationSyntax Build() => (InterfaceDeclarationSyntax) typeDeclaration;
        
        public override AbstractTypeBuilder WithDefinition(string name, string baseType)
        {
            typeDeclaration = SyntaxFactory.InterfaceDeclaration(name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseType)));
            return this;
        }

        public override AbstractTypeBuilder WithMethodDeclarations(Tuple<string, string>[] methodDeclarations)
        {
            foreach(var method in methodDeclarations)
            {
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Item2), method.Item1)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                typeDeclaration = typeDeclaration.AddMembers(methodDeclaration);
            }
            return this;
        }
    }
}
