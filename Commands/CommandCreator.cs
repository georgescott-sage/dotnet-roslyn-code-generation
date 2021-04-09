using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using dotnet_roslyn_code_generation.commands.definitions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_roslyn_code_generation.commands
{
    public interface ICommandCreator
    {
        string CreateInterface(InterfaceDefinition interfaceDefinition);
        string CreateClass(InterfaceDefinition interfaceDefinition);

    }

    public class CommandCreator : ICommandCreator
    {
        public string CreateInterface(InterfaceDefinition interfaceDefinition)
        {
            var interfaceResult = new InterfaceBuilder()
                        .WithInterface(interfaceDefinition.Name(), interfaceDefinition.BaseType(), interfaceDefinition.MethodDeclarations(), interfaceDefinition.Summary())
                        .WithMethodDeclarations(interfaceDefinition.Name(), interfaceDefinition.BaseType(), interfaceDefinition.MethodDeclarations(), interfaceDefinition.Summary())
                        .Build();

            return new CommandInterfaceBuilder()
                .WithNamespace(interfaceDefinition.Namespace())
                .WithReferences(interfaceDefinition.Usings())
                .WithInterface(interfaceResult)
                .Build();
        }

        public string CreateClass(InterfaceDefinition interfaceDefinition)
        {
            var classDefinition = new ClassBuilder()
                        .WithClass(interfaceDefinition.Name(), interfaceDefinition.BaseType(), interfaceDefinition.MethodDeclarations(), interfaceDefinition.Summary())
                        .WithMethods(interfaceDefinition.Name(), interfaceDefinition.BaseType(), interfaceDefinition.MethodDeclarations(), interfaceDefinition.Summary())
                        .Build();

            return new CommandInterfaceBuilder()
                .WithNamespace(interfaceDefinition.Namespace())
                .WithReferences(interfaceDefinition.Usings())
                .WithClass(classDefinition)
                .Build();
        }
    }
}