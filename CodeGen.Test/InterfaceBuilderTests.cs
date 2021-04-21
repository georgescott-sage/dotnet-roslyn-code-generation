using System;
using Xunit;
using codegen.library.builders;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using codegen.library.definitions;

namespace codegen.Test
{
    public class InterfaceBuilderTests
    {
        [Fact]
        public void WhenDefinitionIsProvided_WhenInterfaceIsBuilt_DefinitionIsPresent()
        {
            var name = "test";
            var baseclass = "testBase";
            TypeDeclarationSyntax interfaceResult = new InterfaceBuilder()
                        .WithDefinition(name, baseclass)
                        .Build();

            Assert.Equal($"publicinterface{name}:{baseclass}{{}}", interfaceResult.ToFullString());
        }

        [Fact]
        public void WhenSummaryIsProvided_WhenInterfaceIsBuilt_SummaryIsPresent()
        {
            var summary = "interface to test";
            TypeDeclarationSyntax interfaceResult = new InterfaceBuilder()
                        .WithDefinition("test", "testBase")
                        .WithSummary(summary)
                        .Build();

            Assert.StartsWith($"/// <summary>/// {summary}/// </summary>", interfaceResult.ToFullString());
        }

        [Fact]
        public void WhenMethodIsProvided_WhenInterfaceIsBuilt_MethodIsPresent()
        {
            var method = new MethodDeclaration()
                {
                    Name = "TimeoutAfter", 
                    ReturnType = "TimeSpan"
                };

            TypeDeclarationSyntax interfaceResult = new InterfaceBuilder()
                        .WithDefinition("test", "testBase")
                        .WithMethodDeclarations(new MethodDeclaration[] { method })
                        .Build();
            Console.WriteLine(interfaceResult);
            Assert.EndsWith($"{method.ReturnType}{method.Name}();}}", interfaceResult.ToFullString());
        }
    }
}
