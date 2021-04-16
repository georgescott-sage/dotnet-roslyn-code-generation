using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using codegen.definitions.commands.definitions;

namespace codegen.library.builders
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
                StatementSyntax notImplementedException = SyntaxFactory.ThrowStatement(
                    (ExpressionSyntax) SyntaxFactory.ObjectCreationExpression(
                        SyntaxFactory.ParseTypeName(typeof(NotImplementedException).Name))
                            .WithArgumentList(SyntaxFactory.ArgumentList()));
                
                var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.Type), method.Name)
                    .AddModifiers(GetModifiers(method.Modifiers))
                    .AddParameterListParameters(GetMethodParameters(method.Parameters))
                    .WithBody(SyntaxFactory.Block(notImplementedException));

                typeDeclaration = typeDeclaration.AddMembers(methodDeclaration);
            }
            return this;
        }
    }
}
