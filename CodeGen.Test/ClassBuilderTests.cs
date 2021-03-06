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
        public void WhenMethodIsProvided_ClassIsBuilt_MethodHasParameters()
        {
            var method = new MethodDeclarationBuilder("TimeoutAfter")
                .WithReturnType("TimeSpan")
                .WithParameter(new Parameter("testParam", "string"))
                .Build();
                    //implement method builder return null

            TypeDeclarationSyntax classResult = new ClassBuilder()
                        .WithDefinition("test", "testBase")
                        .WithMethodDeclarations(new MethodDeclaration[] { method })
                        .Build();
            Console.WriteLine(classResult);
            var parameter = $"{method.Parameters[0].Type}{method.Parameters[0].Name}"; 
            Assert.EndsWith($"{method.ReturnType}{method.Name}({parameter}){{thrownewNotImplementedException();}}}}", classResult.ToFullString());
        }

        [Fact]
        public void WhenMethodIsProvided_ClassIsBuilt_MethodBodyThrowsNotImplemented()
        {
            var method = new MethodDeclarationBuilder("TimeoutAfter")
                .WithReturnType("TimeSpan")
                .Build();
                    //implement method builder return null

            TypeDeclarationSyntax classResult = new ClassBuilder()
                        .WithDefinition("test", "testBase")
                        .WithMethodDeclarations(new MethodDeclaration[] { method })
                        .Build();
            Assert.EndsWith($"{method.ReturnType}{method.Name}(){{thrownewNotImplementedException();}}}}", classResult.ToFullString());
        }

        [Fact]
        public void WhenMethodIsProvided_ClassIsBuilt_MethodBodyReturnsNull()
        {
            var method = new MethodDeclarationBuilder("TimeoutAfter")
                .WithReturnType("TimeSpan")
                .Build();
                    //implement method builder return null

            TypeDeclarationSyntax classResult = new ClassBuilder()
                        .WithDefinition("test", "testBase")
                        .WithMethodDeclarations(new MethodDeclaration[] { method })
                        .Build();
            Console.WriteLine(classResult);
            Assert.EndsWith($"{method.ReturnType}{method.Name}(){{returnnull;}}}}", classResult.ToFullString());
        }

        [Fact]
        public void WhenMethodIsProvided_ClassIsBuilt_MethodBodyUsesArrowFunction()
        {
            var method = new MethodDeclarationBuilder("TimeoutAfter")
                .WithReturnType("TimeSpan")
                .Build();
                    //implement method builder return null

            TypeDeclarationSyntax classResult = new ClassBuilder()
                        .WithDefinition("test", "testBase")
                        .WithMethodDeclarations(new MethodDeclaration[] { method })
                        .Build();
            Console.WriteLine(classResult);
            Assert.EndsWith($"{method.ReturnType}{method.Name}()=>null;}}", classResult.ToFullString());
        }
    }
}
