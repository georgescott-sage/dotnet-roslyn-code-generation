using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace dotnet_roslyn_code_generation.builders
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

        public override AbstractTypeBuilder WithMethodDeclarations(MethodDeclaration[] methods)
        {
            foreach(var method in methods)
            {
                var methodParameters = method.Parameters == null ? new ParameterSyntax[0] : 
                    method.Parameters.Select(x => 
                        SyntaxFactory.Parameter(SyntaxFactory.Identifier(x.Item1))
                            .WithType(SyntaxFactory.ParseTypeName(x.Item2))
                    ).ToArray();
                    
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Type), method.Name)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .AddParameterListParameters(methodParameters)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                typeDeclaration = typeDeclaration.AddMembers(methodDeclaration);
            }
            return this;
        }
    }
}
