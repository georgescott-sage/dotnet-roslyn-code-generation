using System;
using System.Collections.Generic;
using dotnet_roslyn_code_generation.builders;

namespace dotnet_roslyn_code_generation.commands.definitions
{
    public class CommandInterfaceDefinition : InterfaceDefinition
    {
        public string BaseType() => "ICustomCommand<UpdateUserCommandRequest, UpdateUserCommandResponse>";

        public MethodDeclaration[] MethodDeclarations() => new MethodDeclaration[]{};

        public string Name() => "IUpdateUserCommand";
        public string Summary() => "Interface defining the command to update a user";
        public string Namespace() => "SBC.Connected.ServiceName.Service.Domain.Core.UseCases.UseCase.Commands.CommandName";

        public IEnumerable<string> Usings() => new List<string>(){ "System", "SBC.Domain.Commands" };
    }
}
