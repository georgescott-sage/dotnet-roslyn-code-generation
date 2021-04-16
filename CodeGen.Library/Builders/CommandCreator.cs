using codegen.definitions.commands.definitions;

namespace codegen.library.builders
{
    public interface ICommandCreator
    {
        string CreateInterface(ITypeDefinition interfaceDefinition);
        string CreateClass(ITypeDefinition interfaceDefinition);

    }

    public class CommandCreator : ICommandCreator
    {
        public string CreateInterface(ITypeDefinition interfaceDefinition)
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

        public string CreateClass(ITypeDefinition interfaceDefinition)
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