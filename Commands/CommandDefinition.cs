using System;
using System.Collections.Generic;
namespace dotnet_roslyn_code_generation.commands.definitions
{
    public class CommandDefinition : InterfaceDefinition
    {
        public string BaseType() => "IUpdateUserCommand";

        public string Name() => "UpdateUserCommand";

        public string Namespace() => "SBC.Connected.Service.Service.Domain.Logic.UseCases.UpdateUser.Commands";

        public string Summary() => "Command to update a user";

        //TODO: properties
        //TODO: constructor params
        //TODO: method params

        public IEnumerable<string> Usings() => new List<string>(){ "System", "SBC.Caching", "System.Data"  };

        public Tuple<string, string>[] MethodDeclarations() 
            => new Tuple<string, string>[]
            {
                Tuple.Create("TimeoutAfter", "TimeSpan"),
                Tuple.Create("LockTTL", "TimeSpan"),
                Tuple.Create("CacheDependencies", "List<ICacheDependency>"),
                Tuple.Create("Owner", "string")
                //public async Task<UpdateBusinessHealthCommandResponse> ExecuteAsync(IDbTransaction transaction, UpdateBusinessHealthCommandRequest request)
            };
    }
}
