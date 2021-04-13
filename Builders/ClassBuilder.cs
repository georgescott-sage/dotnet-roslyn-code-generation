using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using Microsoft.CodeAnalysis;

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

        public override AbstractTypeBuilder WithMethodDeclarations(MethodDeclaration[] methods)
        {
            foreach(var method in methods)
            {
                var creation = SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName(typeof(NotImplementedException).Name)).WithArgumentList(SyntaxFactory.ArgumentList());
                StatementSyntax notImplementedException = SyntaxFactory.ThrowStatement((ExpressionSyntax)creation);
                
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Type), method.Name)
                    .AddModifiers(GetModifiers(method.Modifiers))
                    .AddParameterListParameters(GetMethodParameters(method.Parameters))
                    .WithBody(SyntaxFactory.Block(notImplementedException));

                typeDeclaration = typeDeclaration.AddMembers(methodDeclaration);
            }
            return this;
        }

        private SyntaxToken[] GetModifiers(string[] modifiers)
        {
            return modifiers == null ? new SyntaxToken[0] : 
                modifiers.Select(x => 
                    SyntaxFactory.ParseToken(x)
                ).ToArray();
        }

        private ParameterSyntax[] GetMethodParameters(Tuple<string, string>[] parameters)
        {
            return parameters == null ? new ParameterSyntax[0] : 
                parameters.Select(x => 
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier(x.Item1))
                        .WithType(SyntaxFactory.ParseTypeName(x.Item2))
                ).ToArray();
        }
    }
}
