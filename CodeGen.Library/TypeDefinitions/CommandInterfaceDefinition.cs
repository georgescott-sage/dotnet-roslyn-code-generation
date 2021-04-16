using System;
using System.Collections.Generic;

namespace codegen.library.definitions
{
    public class CommandInterfaceDefinition : ITypeDefinition
    {
        private readonly EndpointDetail _endpoint;

        public CommandInterfaceDefinition(EndpointDetail endpoint)
        {
            _endpoint = endpoint;
        }
        public string BaseType() => $"ICustomCommand<{_endpoint.CommandRequest}, {_endpoint.CommandResponse}>";

        public MethodDeclaration[] MethodDeclarations() => new MethodDeclaration[]{};

        public string Name() => $"I{_endpoint.CommandName}";
        public string Summary() => $"Interface defining the command to {_endpoint.Description}";
        //TODO parse from workspace
        public string Namespace() => "SBC.Connected.ServiceName.Service.Domain.Core.UseCases.UseCase.Commands.CommandName";

        public IEnumerable<string> Usings() => new List<string>(){ "System", "SBC.Domain.Commands" };
    }
}
