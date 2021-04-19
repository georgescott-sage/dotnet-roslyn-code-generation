using System;
using Xunit;
using codegen.library.builders;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using codegen.library.definitions;

namespace codegen.Test
{
    public class ClassBuilderTests
    {
        [Fact]
        public void WhenDefinitionIsProvided_ClassIsBuilt_DefinitionIsPresent()
        {
            var name = "test";
            var baseclass = "testBase";
            TypeDeclarationSyntax ClassResult = new ClassBuilder()
                        .WithDefinition(name, baseclass)
                        .Build();

            Assert.Equal($"publicclass{name}:{baseclass}{{}}", ClassResult.ToFullString());
        }

        [Fact]
        public void WhenSummaryIsProvided_ClassIsBuilt_SummaryIsPresent()
        {
            var summary = "interface to test";
            TypeDeclarationSyntax classResult = new ClassBuilder()
                        .WithDefinition("test", "testBase")
                        .WithSummary(summary)
                        .Build();

            Assert.StartsWith($"/// <summary>/// {summary}/// </summary>", classResult.ToFullString());
        }

        [Fact]
        public void WhenMethodIsProvided_ClassIsBuilt_MethodIsNotImplemented()
        {
            var method = new MethodDeclaration()
                {
                    Name = "TimeoutAfter", 
                    Type = "TimeSpan"
                };

            TypeDeclarationSyntax classResult = new ClassBuilder()
                        .WithDefinition("test", "testBase")
                        .WithMethodDeclarations(new MethodDeclaration[] { method })
                        .Build();
            Console.WriteLine(classResult);
            Assert.EndsWith($"{method.Type}{method.Name}(){{thrownewNotImplementedException();}}}}", classResult.ToFullString());
        }
    }
}
