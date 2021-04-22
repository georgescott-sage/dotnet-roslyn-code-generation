using System;
using System.Collections.Generic;

namespace codegen.library.definitions
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
                new MethodDeclarationBuilder("TimeoutAfter")
                    .WithReturnType("TimeSpan")
                    .Build(),
                new MethodDeclarationBuilder("LockTTL")
                    .WithReturnType("Timespan")
                    .Build(),
                new MethodDeclarationBuilder("CacheDependencies")
                    .WithReturnType("List<ICacheDependency>")
                    .Build(),
                new MethodDeclarationBuilder("Owner")
                    .WithReturnType("string")
                    .Build(),
                new MethodDeclarationBuilder("ExecuteAsync")
                    .WithReturnType("Task<UpdateBusinessHealthCommandResponse>")
                    .WithModifier("public")
                    .WithModifier("async")
                    .WithParameter(Tuple.Create<string, string>("transaction", "IDbTransaction"))
                    .WithParameter(Tuple.Create<string, string>("request", "UpdateBusinessHealthCommandRequest"))
                    .Build()
            };
    }
}
