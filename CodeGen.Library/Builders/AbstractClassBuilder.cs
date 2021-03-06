using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using codegen.library.definitions;
using System.Collections.Generic;

namespace codegen.library.builders
{
    public abstract class AbstractTypeBuilder
    {
        public abstract TypeDeclarationSyntax Build();
        
        protected TypeDeclarationSyntax typeDeclaration;

        public abstract AbstractTypeBuilder WithDefinition(string name, string baseType);

        public abstract AbstractTypeBuilder WithMethodDeclarations(MethodDeclaration[] methodDeclarations);

        public AbstractTypeBuilder WithSummary(string summaryComment)
        {
            typeDeclaration = typeDeclaration
                .WithLeadingTrivia(new SyntaxTriviaList(new SyntaxTriviaList(SyntaxFactory.Comment("/// <summary>"), SyntaxFactory.Comment($"/// {summaryComment}"), SyntaxFactory.Comment("/// </summary>"))));

            return this;
        }

        public SyntaxToken[] GetModifiers(string[] modifiers)
        {
            return modifiers == null ? new SyntaxToken[0] : 
                modifiers.Select(x => 
                    SyntaxFactory.ParseToken(x)
                ).ToArray();
        }

        public ParameterSyntax[] GetMethodParameters(IEnumerable<Parameter> parameters)
        {
            return parameters == null ? new ParameterSyntax[0] : 
                parameters.Select(x => 
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier(x.Name))
                        .WithType(SyntaxFactory.ParseTypeName(x.Type))
                ).ToArray();
        }
    }
}
