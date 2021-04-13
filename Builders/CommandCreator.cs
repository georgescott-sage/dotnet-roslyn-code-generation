using dotnet_roslyn_code_generation.commands.definitions;
using dotnet_roslyn_code_generation.builders;

namespace dotnet_roslyn_code_generation.builders
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
                        .WithDefinition(interfaceDefinition.Name(), interfaceDefinition.BaseType())
                        .WithSummary(interfaceDefinition.Summary())
                        .WithMethodDeclarations(interfaceDefinition.MethodDeclarations())
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
                        .WithDefinition(interfaceDefinition.Name(), interfaceDefinition.BaseType())
                        .WithSummary(interfaceDefinition.Summary())
                        .WithMethodDeclarations(interfaceDefinition.MethodDeclarations())
                        .Build();

            return new CommandInterfaceBuilder()
                .WithNamespace(interfaceDefinition.Namespace())
                .WithReferences(interfaceDefinition.Usings())
                .WithClass(classDefinition)
                .Build();
        }
    }
}