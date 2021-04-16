using System;
using System.Collections.Generic;

namespace codegen.definitions.commands.definitions
{
    public class CommandDefinition : ITypeDefinition
    {
        public string BaseType() => "IUpdateUserCommand";

        public string Name() => "UpdateUserCommand";

        public string Namespace() => "SBC.Connected.Service.Service.Domain.Logic.UseCases.UpdateUser.Commands";

        public string Summary() => "Command to update a user";

        //TODO: properties
        //TODO: constructor params

        public IEnumerable<string> Usings() => new List<string>(){ "System", "SBC.Caching", "System.Data"  };

        public MethodDeclaration[] MethodDeclarations() 
            => new MethodDeclaration[]
            {
                new MethodDeclaration()
                {
                    Name = "TimeoutAfter", 
                    Type = "TimeSpan"
                },
                new MethodDeclaration()
                {
                    Name = "LockTTL", 
                    Type = "TimeSpan"
                },
                new MethodDeclaration()
                {
                    Name = "CacheDependencies", 
                    Type = "List<ICacheDependency>"
                },
                new MethodDeclaration()
                {
                    Name = "Owner", 
                    Type = "string"
                },
                new MethodDeclaration()
                {
                    Name = "ExecuteAsync", 
                    Type = "Task<UpdateBusinessHealthCommandResponse>",
                    Modifiers = new string[] { "public", "async" },
                    Parameters = new Tuple<string, string>[] 
                    {
                        Tuple.Create<string, string>("transaction", "IDbTransaction"),
                        Tuple.Create<string, string>("request", "UpdateBusinessHealthCommandRequest")
                    }
                }
            };
    }
}
