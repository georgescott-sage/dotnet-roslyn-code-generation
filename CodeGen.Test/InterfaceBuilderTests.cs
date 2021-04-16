using System;
using Xunit;
using codegen.library.builders;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace codegen.Test
{
    public class InterfaceBuilderTests
    {
        [Fact]
        public void WhenDefinitionIsProvided_AndInterfaceIsBuilt_DefinitionIsPresent()
        {
            var name = "test";
            var baseclass = "testBase";
            TypeDeclarationSyntax interfaceResult = new InterfaceBuilder()
                        .WithDefinition(name, baseclass)
                        // .WithSummary(interfaceDefinition.Summary())
                        // .WithMethodDeclarations(interfaceDefinition.MethodDeclarations())
                        .Build();

            Assert.Equal(interfaceResult.ToFullString(), $"publicinterface{name}:{baseclass}{{}}");
        }
    }
}
