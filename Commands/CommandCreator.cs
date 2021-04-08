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
            return new CommandInterfaceBuilder()
                .WithNamespace(interfaceDefinition.Namespace())
                .WithReferences(interfaceDefinition.Usings())
                .WithInterface(interfaceDefinition.Name(), interfaceDefinition.BaseType(), interfaceDefinition.MethodDeclarations(), interfaceDefinition.Summary())
                .Build();
        }

        public string CreateClass(InterfaceDefinition interfaceDefinition)
        {
            return new CommandInterfaceBuilder()
                .WithNamespace(interfaceDefinition.Namespace())
                .WithReferences(interfaceDefinition.Usings())
                .WithClass(interfaceDefinition.Name(), interfaceDefinition.BaseType(), interfaceDefinition.MethodDeclarations(), interfaceDefinition.Summary())
                .Build();
        }
    }
}