using System;
using System.Collections.Generic;
namespace dotnet_roslyn_code_generation.commands.definitions
{
    public class CommandDefinition : InterfaceDefinition
    {
        public string BaseType() => "ICustomCommand<UpdateBusinessHealthCommandRequest, UpdateBusinessHealthCommandResponse>";

        public Tuple<string, Type>[] MethodDeclarations() 
            => new Tuple<string, Type>[]
            {
                Tuple.Create("TestMethod", typeof(void))
            };

        public string Name() => "IGetUsersCommand";

        public string Namespace() => "projectnamespacecore";

        public IEnumerable<string> Usings() => new List<string>(){ "System" };
    }
}
