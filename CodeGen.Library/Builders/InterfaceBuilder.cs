using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using codegen.library.definitions;

namespace codegen.library.builders
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
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.ReturnType), method.Name)
                    .AddModifiers(GetModifiers(method.Modifiers.ToArray()))
                    .AddParameterListParameters(GetMethodParameters(method.Parameters.ToArray()))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                typeDeclaration = typeDeclaration.AddMembers(methodDeclaration);
            }
            return this;
        }
    }
}
