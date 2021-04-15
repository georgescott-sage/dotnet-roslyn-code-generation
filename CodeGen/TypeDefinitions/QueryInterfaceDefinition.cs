using System.Collections.Generic;
using dotnet_roslyn_code_generation.builders;
using dotnet_roslyn_code_generation.SampleEndpointDocs;

namespace dotnet_roslyn_code_generation.commands.definitions
{
    public class QueryInterfaceDefinition : ITypeDefinition
    {
        private readonly EndpointDetail _endpoint;

        public QueryInterfaceDefinition(EndpointDetail endpoint)
        {
            _endpoint = endpoint;
        }
        public string BaseType() => $"IQuery<{_endpoint.QueryRequest}, {_endpoint.Resource}>";

        public MethodDeclaration[] MethodDeclarations() => new MethodDeclaration[]{};

        public string Name() => $"I{_endpoint.CommandName}";

        public string Summary() => $"Interface defining the query to {_endpoint.Description}";
        //TODO: parse from workspace
        public string Namespace() => "SBC.Connected.ServiceName.Service.Domain.Core.UseCases.UseCase.Commands.CommandName";

        public IEnumerable<string> Usings() => new List<string>(){ "SBC.Core.AccessControl.Service.Domain.Core.Entities", "SBC.Domain.Queries" };
    }
}
