using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_roslyn_code_generation.builders
{
    public abstract class AbstractTypeBuilder
    {
        public abstract TypeDeclarationSyntax Build();
        
        protected TypeDeclarationSyntax typeDeclaration;

        public abstract AbstractTypeBuilder WithDefinition(string name, string baseType);

        public abstract AbstractTypeBuilder WithMethodDeclarations(Tuple<string, string>[] methodDeclarations);

        public AbstractTypeBuilder WithSummary(string summaryComment)
        {
            typeDeclaration = typeDeclaration
                .WithLeadingTrivia(new SyntaxTriviaList(new SyntaxTriviaList(SyntaxFactory.Comment("/// <summary>"), SyntaxFactory.Comment($"/// {summaryComment}"), SyntaxFactory.Comment("/// </summary>"))));

            return this;
        }
    }
}
